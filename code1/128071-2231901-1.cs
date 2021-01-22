	var s1 = "abc";
	var s2 = "abc";
	var s3 = String.Join("", new[] {"a", "b", "c"});
	var s4 = string.Intern(s3); 
	Console.WriteLine(ReferenceEquals(s1, s2)); // Returns True
	Console.WriteLine(ReferenceEquals(s1, s3)); // Returns False
	Console.WriteLine(s1 == s3); // Returns True
	Console.WriteLine(ReferenceEquals(s1, s4)); // Returns True
