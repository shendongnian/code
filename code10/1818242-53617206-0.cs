    static void Main(string[] args)
    {
        Console.Write("Enter Username: "); // we ask for the username here, you can do it with Console.WriteLine() as well
        string username  = Console.ReadLine();  // get the username
        Console.Write("What class will you be? You can choose from Mage, Warrior, Or Assasin: "); // ask for the class, also same as above, you can use Console.WriteLine()
        string userclass = Console.ReadLine();   // get the class
    
        // Possible character classes (we use this as a reference to check the class the user gives us later)
    	// also set the string representing each class as lower case characters to avoid looping or unnecessary string concatenation later
        string[] charClasses = new string[3] { "mage", "warrior", "assasin" }; // make sure the class given is within our possible character classes
    	
    	// here we check that the class given is within the bound of our possible classes and convert
    	// the userclass to its lower case equivalent to match it with those in the array
        if (Array.IndexOf(charClasses, userclass.ToLower()) != -1)   
        {
    		 // if the class is acceptable then attach it to the message along with the username via string concatenation
            String Message = "You are a strong Willed "+userclass + " " + username; 
            Console.WriteLine(Message);  // print the message
        }
    }
