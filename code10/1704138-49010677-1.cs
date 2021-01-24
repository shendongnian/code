      Console.WriteLine("Type");
      StringBuilder sb = new StringBuilder();     
      string spell = Convert.ToString(Console.ReadLine());
      foreach (var c in spell.ToUpperInvariant().ToCharArray())
      { //make it uppercase to eliminate case sensitivity
         switch (c) 
         {
            case('A'):  //case now evaluates uppercase chars, so single quotes               
                sb.Append("Alfa "); //no need for the local var but add a space
                break;
            //your other cases omitted for brevity
         }   
        
      }
      Console.WriteLine(sb.ToString());
      Console.ReadLine();
