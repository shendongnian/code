    static void Main(string[] args)
    {
      CheckIfIsLocalPath("C:\\foo.txt");
      CheckIfIsLocalPath("C:\\");
      CheckIfIsLocalPath("http://www.txt.com");
    }
    
    private static void CheckIfIsLocalPath(string p)
    {
      var result = IsLocalPath(p); ;
    
      Console.WriteLine("{0}  {1}  {2}", result, p, new Uri(p).AbsolutePath);
    }
