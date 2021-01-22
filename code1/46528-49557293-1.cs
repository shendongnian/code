    }
    
    void Main()
    {
      PatternMatcher patternMatcher = new PatternMatcher();
      Console.WriteLine(patternMatcher.StrictMatchPattern("*.txt", "test.txt")); //displays true
      Console.WriteLine(patternMatcher.StrictMatchPattern("*.doc", "test.txt")); //displays false
    }
