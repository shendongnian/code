        [TestMethod]
        public void StringLiteralDoesNotContainSpaces()
        {
            string query = "hi"
                         + "there";
            Assert.AreEqual("hithere", query);
        }
