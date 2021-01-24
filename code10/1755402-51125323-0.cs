    public List<int> Insert() 
    {
          //Output here something to the console
          List<int> numbers  = new List<int>();
          
          while(true) 
          {
                var input = Console.ReadLine();
                if(input.ToLower() == "done") break;
                try 
                {
                     
                     numbers.Add(Convert.Int32(input));
                }
                catch(FormatException e)
                {
                      Console.WriteLine(e.Message);
                }
         }
         return numbers;
    }
    public void Print(IEnumerable<int> numbers)
    {
         foreach(var num in numbers) 
         {
              Console.WriteLine(num);
         }
    }
