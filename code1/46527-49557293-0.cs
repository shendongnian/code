    public class PatternMatcher
    {
      public delegate bool StrictMatchPatternDelegate(string expression, string name);
      public StrictMatchPatternDelegate StrictMatchPattern;
      public PatternMatcher()
      {
        Type patternMatcherType = typeof(FileSystemWatcher).Assembly.GetType("System.IO.PatternMatcher");
        MethodInfo patternMatchMethod = patternMatcherType.GetMethod("StrictMatchPattern", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
