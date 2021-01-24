    public static class EnumerableX
    { public static void Zip<T1,T2>(this IEnumerable<T1> list1, IEnumerable<T2> list2, Action<T1,T2> act)
      { using (var en1 = list1.GetEnumerator())
        using (var en2 = list2.GetEnumerator())
          while (en1.MoveNext() & en2.MoveNext())
            act(en1.Current, en2.Current);
      }
    }
