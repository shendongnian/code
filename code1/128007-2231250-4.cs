        var solved = false;
        var tries = 0;
        while (!solved)
        {
             try
             {
                //Do Something
                solved = true;
             }
             catch
             {
                 //Fix error
             } 
             finally
             {
                  if(solved || IsRediculous(tries))
                     break;
                  tries++;
             }
        }
