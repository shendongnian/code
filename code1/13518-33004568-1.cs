    using (var wrapper = new MyWrapper())
      {
           wrapper.Start((string1, string2, string3) => 
           {
              Console.WriteLine(string1);
              Console.WriteLine(string2);
              Console.WriteLine(string3);
           }
      }
