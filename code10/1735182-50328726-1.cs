    public static void Main(string[] args) {
      var result = Generate(10) // each line of 10 items
        .Take(7) // 7 lines
        .Select(item => string.Concat(item));
      Console.Write(string.Join(Environment.NewLine, result));
    }
