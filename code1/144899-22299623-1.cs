        public static void Main()
        {
            string myInput;
            int myInt;
            
            StreamReader reader = new StreamReader();
            
            Console.Write("Please enter a number: ");
            myInput = reader.ReadLine();
            myInt = Int32.Parse(myInput);
    
            if (myInt == 10)
            {
                Console.WriteLine("Your number is 10.", myInt);
            }
        }
       
    }
