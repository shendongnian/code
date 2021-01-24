        [TestMethod]
        public void Default()
        {
            (string foo, string bar) MyMethod() => default;
            (string, string) x = default;
            var result = MyMethod();
            // These from your answer are not compilable
            // Assert.IsFalse(x == default);
            // Assert.IsFalse(x == default(string string));
            // Assert.IsFalse(x is default);
            // Assert.IsFalse(x is default(string string));
            Assert.IsFalse(Equals(x, default));
            Assert.IsFalse(Equals(result, default));
            Assert.IsTrue(Equals(x, default((string, string))));
            Assert.IsTrue(Equals(result, default((string, string))));
            Assert.IsTrue(result.Equals(default));
            Assert.IsTrue(x.Equals(default));
            Assert.IsTrue(result.Equals(default((string, string))));
            x.Equals(default((string, string)))
        }
