    // This will write "hello1" to a file called "test.txt".
    System.IO.StreamWriter sw1 = new System.IO.StreamWriter("test.txt");
    sw1.WriteLine("hello1");
    // This will throw a System.IO.IOException because "test.txt" is still locked by 
    // the first StreamWriter.
    System.IO.StreamWriter sw2 = new System.IO.StreamWriter("test.txt");
    sw2.WriteLine("hello2");
