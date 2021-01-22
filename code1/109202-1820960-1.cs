    [TestFixture]
    public class TestEntries {
        [Test]
        public void ShowSize() {
            Entry e = new Entry {
                Items = new List<EntryItem>{
                    new EntryItem { Int32Value = 5265},
                    new EntryItem { SingleValue = 34.23F },
                    new EntryItem { StringValue = "Jorge" }
                }
            };
            var ms = new MemoryStream();
            Serializer.Serialize(ms, e);
            Console.WriteLine(ms.Length);
            Console.WriteLine(BitConverter.ToString(ms.ToArray()));
        }
    }
