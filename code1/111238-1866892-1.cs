    // Get all the members that have an ActiveDirectorySecurityId matching one in the list.
    IEnumerable<Member> members = database.Members
       .Where(member => activeDirectoryIds.Contains(member.ActiveDirectorySecurityId))
       .Select(member => member);
    
    // This is necessary to avoid getting a "Queries with local collections are not supported"
    //error in the next query.    
    memberList = members.ToList<Member>();
    
    // Now get all the roles associated with the members retrieved in the first step.
    IEnumerable<Role> roles = from i in database.MemberRoles
       where memberList.Contains(i.Member)
       select i.Role;
