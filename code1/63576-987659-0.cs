    foreach (var code in ctx.GetType().GetProperties())
            {
                Console.WriteLine(code.PropertyType + " - " + code.Name + " ");
                if (code.PropertyType.ToString().Contains("System.Data.Linq.Table"))
                {
                      //this does not give me what i want here
                      foreach (var pi in code.PropertyType.GetGenericArguments()[0].GetProperties())
                      {
                       Console.WriteLine(pi.Name);
                      }
                }
            }
