        public static bool WarnUser(int passwordValidityPeriod, int passwordExpirationWarningPeriod, out int daysUntilExpiration)
        {
            TimeSpan due;
            bool result = false;
            TimeSpan pwdExpirationWarningPeriod = new TimeSpan(passwordExpirationWarningPeriod, 0, 0, 0);
            TimeSpan pwdValidityPeriod = new TimeSpan(passwordValidityPeriod, 0, 0, 0);
            DirectoryEntry searchRoot = new DirectoryEntry(@"LDAP://DC=YOUR_DOMAIN,DC=com");
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            search.Filter = String.Format("(&(objectClass=user)(objectCategory=person)(sAMAccountName={0}))", Environment.UserName);
            search.PropertiesToLoad.Add("pwdLastSet");
            search.PropertiesToLoad.Add("userAccountControl");
            SearchResult sr = search.FindOne();
            UserAccountControl uac = (UserAccountControl)sr.Properties["userAccountControl"][0];
            var pwdLastSet = DateTime.FromFileTime(long.Parse(sr.Properties["pwdLastSet"][0].ToString()));
            TimeSpan difference = DateTime.Now.Subtract(pwdLastSet);
            due = pwdValidityPeriod - difference;
            //Check for non expiring passwords and do nothing when one is encountered.
            if (!uac.HasFlag(UserAccountControl.DONT_EXPIRE_PASSWD))
            {
                if ((pwdValidityPeriod - difference) <= pwdExpirationWarningPeriod)
                {
                    result = true;
                }
            }
            daysUntilExpiration = ((int)due.TotalDays < 0) ? 0 : (int)due.TotalDays;
            return result;
        }
    }
