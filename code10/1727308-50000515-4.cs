    public class ExampleClass
    {
        private int someProperty = 0;
    
        public void SomeMethod()
        {
            void someNestedMethod()
            {
                int someOtherProperty = 5;
                Console.WriteLine(someProperty); // Output: 0
                Console.WriteLine(someOtherProperty); // Output: 5
            }
            someNestedMethod();
            Console.WriteLine(someProperty); // Output: 0
            Console.WriteLine(someOtherProperty); // Exception thrown, no such property exists
        }
    }
