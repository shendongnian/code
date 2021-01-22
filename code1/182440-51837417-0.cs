    private string ConvertUserNameToDisplayName(string currentSentencedByUsername)
        {
            string name = "";
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                var usr = UserPrincipal.FindByIdentity(context, currentSentencedByUsername);
                if (usr != null)
                    name = usr.GivenName+" "+usr.Surname;
            }
            if (name == "")
                throw new Exception("The UserId is not present in Active Directory");
            return name;
        }
