    class ClassWithMember
    {
        public ClassWithMember()
        {
            SetDefaultValues();
        }
        [DefaultValue(5)]
        public MyIntMember { get; set; }
    }
