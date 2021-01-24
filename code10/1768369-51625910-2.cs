    public class Test
    {
      public int Count;
      public int Sum;
    }
  
    public class TestComparerBySum : IComparer<Test>
    {
      public int Compare(Test x, Test y)
      {
        if (x.Sum > y.Sum) return 1;
        else if (x.Sum < y.Sum) return -1;
        else return 0;
      }
    }
    public class TestComparerByCount : IComparer<Test>
    {
      public int Compare(Test x, Test y)
      {
        if (x.Count > y.Count) return 1;
        else if (x.Count < y.Count) return -1;
        else return 0;
      }
    }
