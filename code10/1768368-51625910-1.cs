    class Test : IComparable
    {
      public int Count;
      public int Sum;
  
      public int CompareTo(object obj)
      {
        if (!(obj is Test))
          throw new ArgumentException("You can't compare two objects of different types!");
                
        var test = (Test)obj;
        if (test.Count < this.Count) return 1;
        else if (test.Count > this.Count) return -1;
        else return 0;
      }
    }
