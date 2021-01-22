    [Flags]
    enum SomeEnum { // formatted for space...
        None = 0, Foo = 1, Bar = 2
    }
    static void Main() {
        SomeEnum value = GetFlags();
        bool hasFoo = (value & SomeEnum.Foo) != 0;
    }
    static SomeEnum GetFlags() { ... }
