    public class ExampleClass
    {
        private int someVariable = 0;
    
        public void SomeMethod()
        {
            void someNestedMethod()
            {
                int someOtherVariable = 5;
                Console.WriteLine(someVariable); // Output: 0
                Console.WriteLine(someOtherVariable); // Output: 5
            }
            someNestedMethod();
            Console.WriteLine(someVariable ); // Output: 0
            Console.WriteLine(someOtherVariable); // Exception thrown, no such property exists
        }
    }
