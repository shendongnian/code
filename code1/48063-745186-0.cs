      int test;
      bool result = Int32.TryParse(value, out test);
      if (result)
      {
         Console.WriteLine("Sucess");         
      }
      else
      {
         if (value == null) value = ""; 
         Console.WriteLine("Failure");
      }
