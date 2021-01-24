     using System.Linq;
     ...
     Dictionary<string, object> dictionary = parameters
     //.Where(line => line.Length == 2 && line[0] != null) // valid params only
       .ToDictionary(line => line[0].ToString(), 
                     line => line[1]);
