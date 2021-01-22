            [TestMethod]
        public void loopTest()
        {
            var series = this.GetSeries();
            series.Reverse();
            foreach (var l in series)
            {
                Debug.WriteLine(l);
            }
        }
        private IEnumerable<long> GetSeries()
        {
            var series = new List<long>() { 1, 2, 3, 4 };
            foreach (var entry in series)
            {
                Debug.WriteLine(entry);
                yield return entry;
            }
        }
