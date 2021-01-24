    foreach (var name in nameList)
        {
          bool match = false;
          foreach(var regex in regexList)
          {
                if (Regex.IsMatch(name, regex))
                {
                    match = true;                  
                    break;
                }  
          }
          if (!match)
              missMatchNameList.Add(name);
        } 
