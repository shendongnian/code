            string folder;
            AuthorizationRuleCollection rules;
            try {
                rules = Directory.GetAccessControl(folder)
                    .GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
            } catch(Exception ex) { //Posible UnauthorizedAccessException
                throw new Exception("No permission", ex);
            }
            var rulesCast = rules.Cast<FileSystemAccessRule>();
            if(rulesCast.Any(rule => rule.AccessControlType == AccessControlType.Deny)
                || !rulesCast.Any(rule => rule.AccessControlType == AccessControlType.Allow))
                throw new Exception("No permission");
            //Here I have permission, ole!
