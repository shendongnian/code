    internal static class EnumerableAsserts
    {
      public static void AreEqual<T>(
          IEnumerable<T> expected, 
          IEnumerable<T> actual)
      {
        AreEqual(expected, actual, null);
      }
      public static void AreEqual<T>(
        IEnumerable<T> expected, 
        IEnumerable<T> actual, 
        string text)
      {
        text = text == null ? "" : text +" : ";
        if (expected == null)
          Assert.Fail("{0}expected is null!", text);
        if (actual == null)
          Assert.Fail("{0}actual is null!", text);
        if (ReferenceEquals(expected, actual))
          return;
        var e = expected.GetEnumerator();
        var a = actual.GetEnumerator();
        int count = 0;
        while (e.MoveNext())
        {
          count++;
          if (a.MoveNext())
          {
            if (!EqualityComparer<T>.Default.Equals(e.Current, a.Current))
              Assert.Fail(
                "{0}the {1}{2} item did not match expected '{3}' but was '{4}'", 
                text, count, MathUtils.GetOrdinal(count), e.Current, a.Current);
          }
          else
          {
            Assert.Fail(
              "{0}there were {1} expected entries but {2} actual entries",
              text, expected.Count(), actual.Count());
          }
        }
        if (a.MoveNext())
          Assert.Fail(
            "{0}there were {1} expected entries but {2} actual entries",
            text, expected.Count(), actual.Count());
      }
    }
