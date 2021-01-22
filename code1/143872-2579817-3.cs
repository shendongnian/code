    static void Main(string[] args) {
      var obj = new Dictionary<string, Dictionary<HashSet<int>, int>>();
      string s = GetTypeName(obj.GetType());
      Console.WriteLine(s);
      Console.ReadLine();
    }
