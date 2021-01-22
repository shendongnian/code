    [Test]
        public void Generator_Should_BeUnigue1()
        {
            //Given
            var loop = Enumerable.Range(0, 1000);
            //When
            var str = loop.Select(x=> RandomStringGenerator.Gen());
            //Then
            var distinct = str.Distinct();
            Assert.AreEqual(loop.Count(),distinct.Count()); // Or Assert.IsTrue(distinct.Count() < 0.95 * loop.Count())
        }
