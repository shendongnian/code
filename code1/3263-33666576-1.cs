    static IEnumerable<string> ParseRange(string str)
    {
        var numbers = str.Trim().Split(',');
        foreach (var n in numbers)
        {
           if (!n.Contains("-")) 
               yield return n;
           else
           {
               string startStr = String.Join("", n.TakeWhile(c => c != '-'));
               int startInt = Int32.Parse(startStr);
               string endStr = String.Join("", n.Reverse().TakeWhile(c => c != '-').Reverse());
               int endInt = Int32.Parse(endStr);
               var range = Enumerable.Range(startInt, endInt - startInt + 1)
                                     .Select(num => num.ToString());
               
               foreach (var s in range)
                   yield return s;
            }
        }
    }
