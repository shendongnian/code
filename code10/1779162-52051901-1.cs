    class Status
    {
        static void Main(string[] args)
        {
            int code = 1;
            string name;
            Dictionary<int, string> StatusMap = new Dictionary<int, string>
            {
                { 1, "ORIGIN" },
                { 2, "ORIGIN" },
                { 3, "ORIGIN" },
                { 4, "IN TRANSIT" }
            };
    
       if (!StatusMap.TryGetValue(code, out name))
       {
           Console.WriteLine(name);
           // Error handling here
       }
      }
    }
    // or a method like this
    public static string GetStatus(int code)
    {
        string name;
        if (!StatusMap.TryGetValue(code, out name)
        {
            // Error handling here
        }
        return name;
    }
