    String str = "Name: Bob\r\n\r\nAge: 32";
	String Name = str.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
	Name = Name.Substring(Name.IndexOf(':') + 1).Trim();
	String Age = str.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[1];
	Age = Age.Substring(Age.IndexOf(':') + 1).Trim();
	Console.WriteLine(Name + "," + Age);
