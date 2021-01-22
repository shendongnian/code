    [Flags]
    enum SomeEnum { // formatted for space...
        None = 0, Foo = 1, Bar = 2 // 4, 8, 16, 32, ...
    }
    static void Main() {
        SomeEnum value = GetFlags();
        bool hasFoo = (value & SomeEnum.Foo) != 0;
    }
    static SomeEnum GetFlags() { ... }
