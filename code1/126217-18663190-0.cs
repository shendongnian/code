    public static bool CurrentUserIsInRole(string role)
    {
        try
        {
            return System.Web.HttpContext.Current.Request
                        .LogonUserIdentity
                        .Groups
                        .Any(x => x.Translate(typeof(NTAccount)).ToString() == role);
            }
            catch (Exception) { return false; }
        }
