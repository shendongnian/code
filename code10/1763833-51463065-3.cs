    public class Foo
    {
        public class int InstanceField;   // This belongs to individual instances
        public static int StaticField;    // This belongs to the class itself 
                                          // (accessed via Foo.StaticField)
        public var ImplicitlyType = 3;    // ERROR: Fields can't be implicitly typed
        public void Bar()
        {
            int notAField;           // This is only accessible in this function,
                                     // Making it a local variable, not a field
            var implicitlyType = 4;  // This works because implicitlyTyped is a local variable
                                     // It's type is also of int, not var
        }
        public void Baz(int alsoNotAField)
        {
            // alsoNotAField is a parameter. It's value will be given from other methods
            // alsoNotAField is also only usable in the scope of this method
            notAField++; // ERROR: notAField can't be used here, because it's limited to Bar()
            
        }
    }
