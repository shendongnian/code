		string Sentence = Console.ReadLine();
		string[] output = Sentence.Split(' ');
		char letter;
		string che = "che";
		StringBuilder sb = null;
		Console.WriteLine("\n");
		string strFinal = "";
		foreach (string s in output)
		{
			letter = s[0];
			sb = new StringBuilder(s);
			if (letter == 'a' || letter == 'A' || letter == 'e' || letter == 'E' || letter == 'i'
			|| letter == 'I' || letter == 'o' || letter == 'O' || letter == 'u' || letter == 'U')
			{
				//  Console.WriteLine("first char of the word is a vowel");
				string s1 = sb.Remove(0, 1).ToString();
				sb.Insert(s1.Length, letter);
				sb.Insert(sb.Length, che);
			}
			else
			{
				sb.Insert(s.Length, che);
				//  Console.WriteLine("first char of a word is a consonant");
			}
			if (s.Length % 2 == 0)
			{
				//  Console.WriteLine("the word has even numbers of letters");
			}
			//Console.WriteLine(firstchar);
			int currentWordLength = s.Length;
			strFinal += sb + " ";
		}
		Console.WriteLine(strFinal);
		Console.ReadKey();
