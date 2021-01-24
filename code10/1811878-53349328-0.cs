    Console.WriteLine("Say any word please: ");
    string s = Console.ReadLine();
	StringBuilder sb = new StringBuilder(s);
	
    for (int i = 0; i < s.Length; i++)
    {
        sb[s.Length - i - 1] = s[i];
    }
	
	string r = sb.ToString();
