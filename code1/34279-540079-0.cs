        public static void hello()
        {
            Console.Write("hello world");
        }
    
       /* code snipped */
        
        public delegate void functionPointer();
        
        functionPointer foo = hello;
        foo();  // Writes hello to the console.
