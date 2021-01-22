    static string SomeFunc<T>(T value) {
        return "Generic";
    }
    static string SomeFunc(int value) {
        return "Non-Generic";
    }
    static void Example() {
        SomeFunc(42);           // Non-Generic
        SomeFunc((object)42);   // Generic
    }
