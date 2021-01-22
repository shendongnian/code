        class Wrapper
        {
            public int Value { get; set; }    
        }
        [TestMethod]
        public void TestMaxValue()
        {
            var dictionary = new Dictionary<string, Wrapper>();
            for (var i = 0; i < 19; i++)
            {
                dictionary[$"s:{i}"] = new Wrapper{Value = (i % 10) * 10 } ;
            }
            var m = dictionary.Keys.MaxValue(x => dictionary[x].Value);
            Assert.AreEqual(m, "s:9");
        }
