    class OuterType {
        //...
        static class FieldInitializer {
            public static readonly SomeType field1, field2;
            static FieldInitializer() {
                //Complicated code that sets both fields together
            }
        }
        //...
    }
