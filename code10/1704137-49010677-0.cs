      Console.WriteLine("Type");
      StringBuilder sb = new StringBuilder();
      bool keepGoing = true;
      while(keepGoing)
      {
        string spell = Convert.ToString(Console.ReadLine()) 
        if(String.IsNullOrWhiteSpace(spell))
        {  keepGoing = false; }
        else
        {
         switch (spell) 
         {
            case("a"):
                string a = "Alfa";
                spell = a;
                sb.Append(spell + " ");
                break;
            //your other cases omitted for brevity
         }   
        }
      }
      Console.WriteLine(sb.ToString());
      Console.ReadLine();
