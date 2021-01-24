    [TestClass]
    public class Test {
        [TestMethod]
        public void JsonConvert() {
            var json = @"{
                ""ComplexData"" : [
                    {
                        ""Folders"" : [
                             ""path/to/A"",
                             ""path/to/B"" // Same here
                         ]
                    },
                    {
                        ""Folders"" : []
                    }
                 ]
            }";
            var result = JsonConvert.DeserializeObject<StartObject>(json);
            result.Should().NotBeNull();
            result.ComplexData[0].Folders[1].Path.Should().Be("path/to/B");
        }
    }
