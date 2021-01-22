    string foo;
    public string Foo {
        get {
            return foo;
        }
        set {
            foo = value;
        }
    }
    // becomes
    string foo;
    public string get_Foo() {
        return foo;
    }
    public void set_Foo(string value) {
        foo = value;
    }
