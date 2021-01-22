    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        // This method must be thread-safe since it is called by the thread-safe OnCacheAuthorization() method.
        protected virtual bool AuthorizeCore(HttpContextBase httpContext) {
            base.AuthorizeCore(httpContext);
            if ((!string.IsNullOrEmpty(Users) && (_usersSplit.Length == 0))
               (!string.IsNullOrEmpty(Roles) && (_rolesSplit.Length == 0)))
            {
                // wish base._usersSplit were protected instead of private...
                InitializeSplits();                
            }
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated) {
                return false;
            }
            var userRequired = _usersSplit.Length > 0);
            var userValid = userRequired
                && _usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase);
            var roleRequired = _rolesSplit.Length > 0);
            var roleValid = (roleRequired) 
                && _roleSplit.Any(user.IsInRole);
            var userOrRoleRequired = userRequired || roleRequired;
            return (!userOrRoleRequired) || userValid || roleValid;
        }
        private string[] _rolesSplit = new string[0];
        private string[] _usersSplit = new string[0];
        private void InitializeSplits()
        {
            lock(this)
            {
                if ((_rolesSplit.Length == 0) || (_usersSplit.Length == 0))
                {
                    _rolesSplit = SplitString(Roles);
                    _usersSplit = SplitString(Users);
                }
            }
        }
    }
