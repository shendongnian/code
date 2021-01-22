    // C# file exported to .winmd class library for use in metro app
    namespace A
    {
        public sealed class B
        {
            public B(bool bTest)
            {}
            // Other methods/members...
        }
    }
    // C++ metro app referencing .winmd created from C# above
    ...
    A::B^ spB = ref new A::B(bTest);  // Throws an exception
