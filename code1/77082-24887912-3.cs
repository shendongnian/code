        private bool IsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            if (identity != null)
            {
               WindowsPrincipal principal = new WindowsPrincipal(identity);
               List<Claim> list = new List<Claim>(principal.UserClaims);
               Claim c = list.Find(p => p.Value.Equals("S-1-5-32-544"));
               if (c != null)
                    return true;
            }
            return false;
        }
