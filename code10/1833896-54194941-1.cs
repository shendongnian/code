    var s = "Test,Test,this is some free text, thanks";
	var a = s.Split(new[] {','}, 3);  // return at most 3 items
    Console.WriteLine(a[0]); // prints Test
    Console.WriteLine(a[1]); // prints Test
    Console.WriteLine(a[2]); // prints this is some free text, thanks
