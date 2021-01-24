             static Person GlobalBob;  // must be static because we are instantiating it inside a static method
            class Person
            {
                public string jobTitle = "Cashier";
                public void Greet()
                {
                    Console.WriteLine("Hi, im bob.");
                }
            }
            public static void Main(string[] args)   //Method it was instantiated in
            {
                GlobalBob = new Person();
                GlobalBob.Greet();
                OtherMethod();                       //Call your OtherMethod here otherwise it's not gonna be executed
            }
            public static void OtherMethod()      //Method I want to access it in
            {
                GlobalBob.Greet();
                Console.WriteLine(GlobalBob.jobTitle);  //Here we have access to GlobalBob 
                Console.ReadLine(); //Wait for you to press a key so you can read the output !
            }
        }
