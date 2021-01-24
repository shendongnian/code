		string test = "(LIST (LIST 'Constant 'Malachi 'J ) '1832878847 'mconstant@mail.usi.edu 4.0000000000000000 )";
		
		test = test.Replace(")","");
		
		string[] abc = test.Split(new string[] { "'" }, StringSplitOptions.None);
		
		Console.WriteLine("Last Name =" + abc[1]);
		Console.WriteLine("First Name =" + abc[2]);
		Console.WriteLine("Middle Initial =" + abc[3]);
		Console.WriteLine("Email gpa =" + abc[abc.Length-1]);
