        public static IEnumerable<int> QSort3(IEnumerable<int> source)
        {
            if (!source.Any())
                return source;
            int first = source.First();
            QSort3Helper myHelper = 
              source.GroupBy(i => i.CompareTo(first))
              .Aggregate(new QSort3Helper(), (a, g) =>
                  {
                      if (g.Key == 0)
                          a.Same = g;
                      else if (g.Key == -1)
                          a.Less = g;
                      else if (g.Key == 1)
                          a.More = g;
                      return a;
                  });
            IEnumerable<int> myResult = Enumerable.Empty<int>();
            if (myHelper.Less != null)
                myResult = myResult.Concat(QSort3(myHelper.Less));
            if (myHelper.Same != null)
                myResult = myResult.Concat(myHelper.Same);
            if (myHelper.More != null)
                myResult = myResult.Concat(QSort3(myHelper.More));
            return myResult;
        }
        public class QSort3Helper
        {
            public IEnumerable<int> Less;
            public IEnumerable<int> Same;
            public IEnumerable<int> More;
        }
