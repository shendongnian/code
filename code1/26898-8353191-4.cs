    public sealed class AuthenticationMethod : EnumBase<AuthenticationMethod, int>
    {
        public static readonly AuthenticationMethod FORMS =
            new AuthenticationMethod(1, "FORMS");
        public static readonly AuthenticationMethod WINDOWSAUTHENTICATION =
            new AuthenticationMethod(2, "WINDOWS");
        public static readonly AuthenticationMethod SINGLESIGNON =
            new AuthenticationMethod(3, "SSN");
        private AuthenticationMethod(int Value, String Name)
            : base( Value, Name ) { }
        public new static IEnumerable<AuthenticationMethod> All
        { get { return EnumBase<AuthenticationMethod, int>.All; } }
        public static explicit operator AuthenticationMethod(string str)
        { return Parse(str); }
    }
