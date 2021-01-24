      foreach(String string1 in LB1.Items)
      {
        foreach(String string2 in LB2.Items)
        {
          cat1 = string1.Substring(0, string1.Length - 4);
          cat2 = string2.Substring(0, string2.Length - 5);
          if(cat1.Equals(cat2))
          {
            Listbox1.Items.Remove(string1);
            // if you want to stop after the first match, break; 
            // else remove break to find all matches;
                  
            break;
          }
        }
      }
