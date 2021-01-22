    using StoreBox = System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>; 
    using ListOfStrings = System.Collections.Generic.List<string>; 
    class Program
    {
        static void Main(string[] args)
        {
          var b = new StoreBox ();
          b.Add("Red", new ListOfStrings {"Rosso", "red" });
          b.Add("Green", new ListOfStrings {"Verde", "green" });
        }
    }
