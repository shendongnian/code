    public static class AssertionExt
    {
      public static bool AreSequencesEqual<T>( IEnumerable<T> expected, 
                                               IEnumerable<T> sequence )
      {
        Assert.AreEqual(expected.Count(), sequence .Count()); 
     
        IEnumerator<Token> e1 = expected.GetEnumerator(); 
        IEnumerator<Token> e2 = sequence .GetEnumerator(); 
     
        while (e1.MoveNext() && e2.MoveNext()) 
        { 
            Assert.AreEqual(e1.Current, e2.Current); 
        }
      }
    }
