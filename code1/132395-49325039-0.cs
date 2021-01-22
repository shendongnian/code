    public class InitParam
    {
        public const int MyInt_Default = 32;
        public const bool MyBool_Default = true;
        [DefaultValue(MyInt_Default)]
        public int MyInt{ get; set; } = MyInt_Default;
        [DefaultValue(MyBool_Default)]
        public bool MyBool{ get; set; } = MyBool_Default;
    }
