    object obj1 = "Object One";     //string value is stored in Object type variable
    object obj2 = new string("Object One".ToCharArray());  //Explicit conversion
	Console.WriteLine(obj1);        //Output is Object One
	Console.WriteLine(obj2);        //Output is Object One
    Console.WriteLine(obj1 == obj2);  //Since == compares both reference and value, hence the false output
    Console.WriteLine(obj1.Equals(obj2));  //Equals() compares just the value, hence the true result
