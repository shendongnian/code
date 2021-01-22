        public enum UrlStatus { A,B }
        public enum TrafficEntry { A }
        [ProtoContract]
        public class SerializableException { }
    
        [Test]
        public void TestBasicRoundTrip()
        {
            var item = new ProtoDictionary<string>();
            item.Add("abc", "def");
            item.Add("ghi", new List<UrlStatus> {UrlStatus.A, UrlStatus.B});
            var clone = Serializer.DeepClone(item);
            Assert.AreEqual(2, clone.Keys.Count);
            object o = clone["abc"];
            Assert.AreEqual("def", clone["abc"].Value);
            var list = (IList<UrlStatus>)clone["ghi"].Value;
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(UrlStatus.A, list[0]);
            Assert.AreEqual(UrlStatus.B, list[1]);
        }
