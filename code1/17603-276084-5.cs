        /// <summary>
        /// .NET 1.1 CLR
        /// </summary>
        [Test]
        public void Tester_fornet_1_dot_1()
        {
            const int initialSize = 1000;
            // Create the baseline data
            int[] myArray = new int[initialSize];
            for (var i = 0; i < initialSize; i++)
            {
                myArray[i] = i + 1;
            }
            IEnumerable _revered = ReverserService.ToReveresed(myArray);
            Assert.IsTrue(TestAndGetResult(_revered).Equals(1000));
        }
        [Test]
        public void tester_why_this_is_good()
        {
            ArrayList names = new ArrayList();
            names.Add("Jim");
            names.Add("Bob");
            names.Add("Eric");
            names.Add("Sam");
            IEnumerable _revered = ReverserService.ToReveresed(names);
            Assert.IsTrue(TestAndGetResult(_revered).Equals("Sam"));
        }
        [Test]
        public void tester_extension_method()
      {
            // Extension Methods No Linq (Linq does this for you as I will show)
            var enumerableOfInt = Enumerable.Range(1, 1000);
            // Use Extension Method - which simply wraps older clr code
            IEnumerable _revered = enumerableOfInt.ToReveresed();
            Assert.IsTrue(TestAndGetResult(_revered).Equals(1000));
        }
        [Test]
        public void tester_linq_3_dot_5_clr()
        {
            // Extension Methods No Linq (Linq does this for you as I will show)
            IEnumerable enumerableOfInt = Enumerable.Range(1, 1000);
            // Reverse is Linq (which is are extension methods off IEnumerable<T>
            // Note you must case IEnumerable (non generic) using OfType or Cast
            IEnumerable _revered = enumerableOfInt.Cast<int>().Reverse();
            Assert.IsTrue(TestAndGetResult(_revered).Equals(1000));
        }
        [Test]
        public void tester_final_and_recommended_colution()
        {
            var enumerableOfInt = Enumerable.Range(1, 1000);
            enumerableOfInt.PerformOverReversed(i => Debug.WriteLine(i));
        }
        private static object TestAndGetResult(IEnumerable enumerableIn)
        {
          //  IEnumerable x = ReverserService.ToReveresed(names);
            Assert.IsTrue(enumerableIn != null);
            IEnumerator _test = enumerableIn.GetEnumerator();
            // Move to first
            Assert.IsTrue(_test.MoveNext());
            return _test.Current;
        }
    }
