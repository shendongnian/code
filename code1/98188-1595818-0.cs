    void MyMethod(List<string> list) {
      list.Add("foo");
    }
    
    void Example() {
      List<string> l = new List<sting>();
      MyMethod(l);
      Console.WriteLine(l.Count);  // Prints 1
      MyMethod(l);
      Console.WriteLine(l.Count);  // Prints 2
    }
