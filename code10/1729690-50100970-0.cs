        [TestMethod]
        public void Default()
        {
            (string foo, string bar) MyMethod() => default;
            (string, string) x = default;
            // Later
            var result = MyMethod();
            Assert.IsFalse(Equals(x, default));
            Assert.IsFalse(Equals(result, default));
        }
