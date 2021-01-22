    public class PatternMatcher
    {
      public delegate bool StrictMatchPatternDelegate(string expression, string name);
      public StrictMatchPatternDelegate StrictMatchPattern;
      public PatternMatcher()
      {
        Type patternMatcherType = typeof(FileSystemWatcher).Assembly.GetType("System.IO.PatternMatcher");
        MethodInfo patternMatchMethod = patternMatcherType.GetMethod("StrictMatchPattern", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        StrictMatchPattern = (expression, name) => (bool)patternMatchMethod.Invoke(null, new object[] { expression, name });
      }
    }
    
    void Main()
    {
      PatternMatcher patternMatcher = new PatternMatcher();
      Console.WriteLine(patternMatcher.StrictMatchPattern("*.txt", "test.txt")); //displays true
      Console.WriteLine(patternMatcher.StrictMatchPattern("*.doc", "test.txt")); //displays false
    }
