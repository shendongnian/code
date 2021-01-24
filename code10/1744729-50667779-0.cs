     Dictionary<string, string> myDictionary = myArray.Select(l => 
         { 
            var splittedStrings = l.Split('=');
            return new { Key = splittedStrings[0], Val = splittedStrings[1] };
          }).GroupBy(g => g.Key)
         .ToDictionary(a => a.Key, a => a.First().Val);
