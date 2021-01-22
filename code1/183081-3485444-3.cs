        [Test]
        public void Test_ImmutableList()
        {
            var expected = ImmutableList.Create("zoo", "bar", "foo");
            var input = ImmutableList.Create("foo", "bar", "baz");
            var inputSave = input.AsImmutable();
            var actual = input
                    .Add("foo")
                    .RemoveAt(0)
                    .Replace(0, "zoo")
                    .Insert(1, "bar")
                    .Remove("baz");
            
            Assert.AreEqual(inputSave, input, "Input collection was modified");
            Assert.AreEqual(expected, actual);
        }
