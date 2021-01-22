    public static class ExtensionMethods
    {
              public static StringBuilder  replace(this StringBuilder Sb1,string input, 
              Func<string> anonymos)
              {
                   return Sb1.Replace(input, anonymos.Invoke());
              }
    }
