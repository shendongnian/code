     using System.Linq;
     ...
     Dictionary<string, object> dictionary = parameters
       .ToDictionary(line => line[0].ToString(), 
                     line => line[1]);
