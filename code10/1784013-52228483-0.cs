        [Fact]
        public void Replace_value_in_dict()
        {
            // given
            var mydict = new Dictionary<string, string>
            {
                { "key1", "donothing" },
                { "key2", "23;32;323;34;45" },
            };
            // when
            var result = mydict
                .Select(kv => (kv.Key, Regex.Replace(kv.Value, @"\b23\b", "X")))
                .ToDictionary(x => x.Item1, x => x.Item2);
            // then
            Assert.Equal(result, new Dictionary<string, string>
            {
                { "key1", "donothing" },
                { "key2", "X;32;323;34;45" },
            });
        }
