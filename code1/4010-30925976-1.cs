    [TestClass]
    public class TakeRandomTests
    {
        /// <summary>
        /// Ensure that when randomly choosing items from an array, all items are chosen with roughly equal probability.
        /// </summary>
        [TestMethod]
        public void TakeRandom_Array_Uniformity()
        {
            const int numTrials = 2000000;
            const int expectedCount = numTrials/20;
            var timesChosen = new int[100];
            var century = new int[100];
            for (var i = 0; i < century.Length; i++)
                century[i] = i;
            for (var trial = 0; trial < numTrials; trial++)
            {
                foreach (var i in century.TakeRandom(5, 100))
                    timesChosen[i]++;
            }
            var avg = timesChosen.Average();
            var max = timesChosen.Max();
            var min = timesChosen.Min();
            var allowedDifference = expectedCount/100;
            AssertBetween(avg, expectedCount - 2, expectedCount + 2, "Average");
            //AssertBetween(min, expectedCount - allowedDifference, expectedCount, "Min");
            //AssertBetween(max, expectedCount, expectedCount + allowedDifference, "Max");
            var countInRange = timesChosen.Count(i => i >= expectedCount - allowedDifference && i <= expectedCount + allowedDifference);
            Assert.IsTrue(countInRange >= 90, String.Format("Not enough were in range: {0}", countInRange));
        }
        /// <summary>
        /// Ensure that when randomly choosing items from an IEnumerable that is not an IList, 
        /// all items are chosen with roughly equal probability.
        /// </summary>
        [TestMethod]
        public void TakeRandom_IEnumerable_Uniformity()
        {
            const int numTrials = 2000000;
            const int expectedCount = numTrials / 20;
            var timesChosen = new int[100];
            for (var trial = 0; trial < numTrials; trial++)
            {
                foreach (var i in Range(0,100).TakeRandom(5, 100))
                    timesChosen[i]++;
            }
            var avg = timesChosen.Average();
            var max = timesChosen.Max();
            var min = timesChosen.Min();
            var allowedDifference = expectedCount / 100;
            var countInRange =
                timesChosen.Count(i => i >= expectedCount - allowedDifference && i <= expectedCount + allowedDifference);
            Assert.IsTrue(countInRange >= 90, String.Format("Not enough were in range: {0}", countInRange));
        }
        private IEnumerable<int> Range(int low, int count)
        {
            for (var i = low; i < low + count; i++)
                yield return i;
        }
        private static void AssertBetween(int x, int low, int high, String message)
        {
            Assert.IsTrue(x > low, String.Format("Value {0} is less than lower limit of {1}. {2}", x, low, message));
            Assert.IsTrue(x < high, String.Format("Value {0} is more than upper limit of {1}. {2}", x, high, message));
        }
        private static void AssertBetween(double x, double low, double high, String message)
        {
            Assert.IsTrue(x > low, String.Format("Value {0} is less than lower limit of {1}. {2}", x, low, message));
            Assert.IsTrue(x < high, String.Format("Value {0} is more than upper limit of {1}. {2}", x, high, message));
        }
    }
