        [TestMethod]
        public void TestSerialize()
        {
            var serializer = new MetroLineJSONSerializationStrategy();
            serializer.Source = new MetroLineDetails("Inland Empire Line", Colors.Blue, 'A', "LA Union Station", "San Bernardino", true, true);
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    serializer.Save(writer);
                }
                var bytes = stream.GetBuffer();
                var json = System.Text.Encoding.UTF8.GetString(bytes);
                Assert.AreEqual('{', json[0]);
            }
        }
