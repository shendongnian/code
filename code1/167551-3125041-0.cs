     public IEnumerable<string> Strings
     {
         get
         {
              foreach (var s in _strings) yield return s;
         }
     }
