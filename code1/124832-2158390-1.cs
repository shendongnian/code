         var t = typeof(DateTime);
         string[] validMethods = { "ToString" };
         var parameters = new[] { typeof(string) };
            
         return t.GetMethods()
                 .Where
                 (
                    a => validMethods.Contains(a.Name)
                         && 
                         a.GetParameters()
                          .Select(p => p.ParameterType)
                          .SequenceEqual(parameters)
                 )
                 .ToArray();
