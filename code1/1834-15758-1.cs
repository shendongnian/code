            static void Main(string[] args)
            {
    #if DEBUG
                //this only compiles if in DEBUG
                Console.WriteLine("DEBUG")
    #endif 
    #if !DEBUG
                //this only compiles if not in DEBUG
                Console.WriteLine("RELEASE")
    #endif
                //This always compiles
                Console.ReadLine()
            }
