      [Test]
            public void ExtensionsTests_ArrayExtensionTests()
            {
                var data = new[] { 'A', 'B', 'C', 'D' };
    
                Assert.AreEqual("BCD", string.Join("", data.RemoveFirstElement()));
                Assert.AreEqual("ABC", string.Join("", data.RemoveLastElement()));
            }
