    public static void Main(string[] args)
    {
        List<char> array = new List<char>();
        randomWord = "apple".ToCharArray();
        Console.WriteLine(randomWord);
        while (guessing == true) {
    
    
			Console.WriteLine();
		
		
			userinput = char.Parse(Console.ReadLine());
		
			for (int i = 0; i < randomWord.Length; i++)
			{
				if (randomWord[i].ToString().Contains(userinput))
				{
		
				   Console.Write(userinput);
				   //add to array
					array.Add(randomWord[i]);
		
				}
				else
				{
				   //it's not clear what you want to add to here?
				   Console.Write("_ ");
				}
			}
			//and here Write whole array
			//use a foreach
			foreach(char c in array ){
			   Console.Write(c);
			}
		//your missing a brace
        }
    }
