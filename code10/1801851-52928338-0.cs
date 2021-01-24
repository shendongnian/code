      List<Int32> Numbers=new List<int>();
      Console.WriteLine("Enter 5 unique numbers");
      while (Numbers.Count<5) {
        int result=-1;
        Boolean IsNumber=Int32.TryParse(Console.ReadLine(),out result);
        if (IsNumber==false) {
          Console.WriteLine("Please enter a number!!!");
          continue;
        }
          
        if (Numbers.IndexOf(result)>=0) {
          Console.WriteLine("Hold on, you already entered that number. Try again.");
          continue;
        }
        Numbers.Add(result);
      }
