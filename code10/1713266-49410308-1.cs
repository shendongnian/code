	private static List<Personnel> ReadTest() 
    {
        int count = 0;
        string line;
        Char c = ';';
        StreamReader file= new StreamReader("Listing.csv");
		var Workers = new List<Personnel>();
		
        while ((line= file.ReadLine()) != null)
        {
            String[] substrings = line.Split(c);
			var person = new Personnel(); 
			person.firstname = substrings[0];
			person.lastname = substrings[1]; 
			person.function = substrings[2]; 
			//continue until all variables assigned. 
			Workers.Add(person); 
            count++;
        }
        file.Close();
        System.Console.WriteLine("Number of lines : {0}.", count);
		return Workers; 
    }
    static void Main(string[] args)
    {
        List<Personnel> Workers = ReadTest();
    }
