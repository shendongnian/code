    public static string CurrentUserName
    {
        get
        {
            System.Security.Principal.IPrincipal _User;
            _User = System.Web.HttpContext.Current.User;
            System.Security.Principal.IIdentity _Identity;
            _Identity = _User.Identity;
            string _Value;
            _Value = _Identity.Name.Substring(_Identity.Name.IndexOf(@"\")+1);
            return _Value;
        }
    }
    public static string CurrentDomain
    {
        get
        {
            System.Security.Principal.IPrincipal _User;
            _User = System.Web.HttpContext.Current.User;
            System.Security.Principal.IIdentity _Identity;
            _Identity = _User.Identity;
            string _Value;
            _Value = _Identity.Name.Substring(0, _Identity.Name.IndexOf(@"\"));
            return _Value;
        }
    }
