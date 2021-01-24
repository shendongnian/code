    public static List<string> GetGroupMemberList(DirectoryEntry group, bool recurse = false, Dictionary<string, string> domainSidMapping = null) {
        var members = new List<string>();
        
        group.RefreshCache(new[] { "member", "canonicalName" });
        
        if (domainSidMapping == null) {
            //Find all the trusted domains and create a dictionary that maps the domain's SID to its DNS name
            var groupCn = (string) group.Properties["canonicalName"].Value;
            var domainDns = groupCn.Substring(0, groupCn.IndexOf("/", StringComparison.Ordinal));
            
            var domain = Domain.GetDomain(new DirectoryContext(DirectoryContextType.Domain, domainDns));
            var trusts = domain.GetAllTrustRelationships();
            
            domainSidMapping = new Dictionary<string, string>();
            
            foreach (TrustRelationshipInformation trust in trusts) {
                if (trust.TargetName.Contains("ccm")) continue;
                using (var trustedDomain = new DirectoryEntry($"LDAP://{trust.TargetName}")) {
                    try {
                        trustedDomain.RefreshCache(new [] {"objectSid"});
                        var domainSid = new SecurityIdentifier((byte[]) trustedDomain.Properties["objectSid"].Value, 0).ToString();
                        domainSidMapping.Add(domainSid, trust.TargetName);
                    } catch (Exception e) {
                        //This can happen if you're running this with credentials
                        //that aren't trusted on the other domain or if the domain
                       //can't be contacted
                       Console.WriteLine($"Can't connect to domain {trust.TargetName}: {e.Message}");
                    }
                }
            }
        }
        
        while (true) {
            var memberDns = group.Properties["member"];
            foreach (var member in memberDns) {
                using (var memberDe = new DirectoryEntry($"LDAP://{member}")) {
                    memberDe.RefreshCache(new[] { "objectClass", "msDS-PrincipalName", "cn" });
                    if (recurse && memberDe.Properties["objectClass"].Contains("group")) {
                        members.AddRange(GetGroupMemberList(memberDe, true, domainSidMapping));
                    } else if (memberDe.Properties["objectClass"].Contains("foreignSecurityPrincipal")) {
                        //User is on a trusted domain
                        var foreignUserSid = memberDe.Properties["cn"].Value.ToString();
                        //The SID of the domain is the SID of the user minus the last block of numbers
                        var foreignDomainSid = foreignUserSid.Substring(0, foreignUserSid.LastIndexOf("-"));
                        if (domainSidMapping.TryGetValue(foreignDomainSid, out var foreignDomainDns)) {
                            using (var foreignUser = new DirectoryEntry($"LDAP://{foreignDomainDns}/<SID={foreignUserSid}>")) {
                                foreignUser.RefreshCache(new[] { "msDS-PrincipalName" });
                                members.Add(foreignUser.Properties["msDS-PrincipalName"].Value.ToString());
                            }
                        } else {
                            //unknown domain
                            members.Add(foreignUserSid);
                        }
                    } else {
                        var username = memberDe.Properties["msDS-PrincipalName"].Value.ToString();
                        if (!string.IsNullOrEmpty(username)) {
                            members.Add(username);
                        }
                    }
                }
            }
        
            if (memberDns.Count == 0) break;
        
            try {
                group.RefreshCache(new[] {$"member;range={members.Count}-*"});
            } catch (COMException e) {
                if (e.ErrorCode == unchecked((int) 0x80072020)) { //no more results
                    break;
                }
                throw;
            }
        }
        return members;
    }
