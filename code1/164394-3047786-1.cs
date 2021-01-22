        [Test]
        public void Test()
        {
            var collection = new List<Fake>()
                                 {
                                     new Fake {Value = "c"},
                                     new Fake {Value = "b"},
                                     new Fake {Value = "a"},
                                     new Fake {Value = "a"}
                                 };
            var result =
                collection.GroupBy(a => a.Value, a => a).OrderBy(b => b.Key).ToList();
            foreach(var group in result)
            {
                Console.WriteLine(group.Key);
            }
        }
        private class Fake
        {
            public string Value { get; set; }
        }
