    private static IEnumerable<string> UseConcurrentBag(int count)
        {
            Func<string> getString = () => "42";
            var list = new ConcurrentBag<string>();
            Parallel.For(0, count, o => list.Add(getString()));
            return list;
        }
        private static IEnumerable<string> UseLocalLock(int count)
        {
            Func<string> getString = () => "42";
            var resultCollection = new List<string>();
            object localLockObject = new object();
            Parallel.For(0, count, () => new List<string>(), (word, state, localList) =>
            {
                localList.Add(getString());
                return localList;
            },
                (finalResult) => { lock (localLockObject) resultCollection.AddRange(finalResult); }
                );
            return resultCollection;
        }
        private static void Test()
        {
            var s = string.Empty;
            var start1 = DateTime.Now;
            var list = UseConcurrentBag(5000000);
            if (list != null)
            {
                var end1 = DateTime.Now;
                s += " 1: " + end1.Subtract(start1);
            }
            var start2 = DateTime.Now;
            var list1 = UseLocalLock(5000000);
            if (list1 != null)
            {
                var end2 = DateTime.Now;
                s += " 2: " + end2.Subtract(start2);
            }
            if (!s.Contains("sdfsd"))
            {
            }
        }
