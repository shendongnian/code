        [TestMethod]
        public void TestMethod()
        {
            var list = 
                new[]
                    {
                        new {Id = 0005, HValue = 0, Limit = 350}, 
                        new {Id = 0005, HValue = 1, Limit = 0}, 
                        new {Id = 0005, HValue = 2, Limit = 350}, 
                        new {Id = 0005, HValue = 3, Limit = 350}, 
                        new {Id = 0025, HValue = 0, Limit = 20}, 
                        new {Id = 0025, HValue = 1, Limit = 0}
                    };
            var query =
                from row in list
                group row by row.Id
                into groupedById
                where groupedById.Count() > 1
                select
                    new
                        {
                            Id = groupedById.Key,
                            HValueCollection = groupedById.Select(x => x.HValue),
                            LimitCollection = groupedById.Select(x => x.Limit)
                        };
            Assert.AreEqual(2, query.Count());
            var firstResult = query.First();
            Assert.AreEqual(0005, firstResult.Id);
            Assert.AreEqual(4, firstResult.HValueCollection.Distinct().Count());
            Assert.AreEqual(2, firstResult.LimitCollection.Distinct().Count());
            var lastResult = query.Last();
            Assert.AreEqual(0025, lastResult.Id);
            Assert.AreEqual(2, lastResult.HValueCollection.Distinct().Count());
            Assert.AreEqual(2, lastResult.LimitCollection.Distinct().Count());
        }
