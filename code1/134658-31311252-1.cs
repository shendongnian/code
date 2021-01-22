        [TestMethod]
        public void SerializeEmptyCollectionInExtensibleType_RemainEmpty()
        {
            var instance = new Store { Products = new List<string>() };
            // serialize-deserialize using cloning
            var clone = Serializer.DeepClone(instance);
            // clone is not null and empty
            Assert.IsNotNull(clone.Products);
            Assert.AreEqual(0, clone.Products.Count);
        }
        [ProtoContract]
        public class Store : Extensible
        {
            [ProtoMember(1)]
            public List<string> Products { get; set; }
            [OnSerializing]
            public void OnDeserializing()
            {
                var productsListIsEmpty = this.Products != null && this.Products.Count == 0;
                Extensible.AppendValue(this, 101, productsListIsEmpty);
            }
            [OnDeserialized]
            public void OnDeserialized()
            {
                var productsListIsEmpty = Extensible.GetValue<bool>(this, 101);
                if (productsListIsEmpty)
                    this.Products = new List<string>();
            }
        }
