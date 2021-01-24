    public class MainClass
    {
    
        class Hero
        {
            public string FirstName {get; set;}
            public string LastName {get; set;}
            public int Age {get; set;}
        }
    
        public static void Main()
        {
            Hero avenger = new Hero
            {
                FirstName = "Steve",
                LastName = "Rogers",
                Age = 126
            };
    
            Console.WriteLine(avenger.FirstName);
        }  
    }
