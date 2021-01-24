    using (System.IO.StreamWriter sw1 = new System.IO.StreamWriter("test.txt"))
    {
      sw1.WriteLine("hello1");
    }
    using (System.IO.StreamWriter sw2 = new System.IO.StreamWriter("test.txt"))
    {
      sw2.WriteLine("hello2");
    }
