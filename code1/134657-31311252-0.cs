        [TestMethod]
        public void SerializeEmptyCollectionUsingSurrogate_RemainEmpty()
        {
            var instance = new SomeType { Items = new List<int>() };
            // set the surrogate
            RuntimeTypeModel.Default.Add(typeof(SomeType), true).SetSurrogate(typeof(SomeTypeSurrogate));
            // serialize-deserialize using cloning
            var clone = Serializer.DeepClone(instance);
         
            // clone is not null and empty
            Assert.IsNotNull(clone.Items);
            Assert.AreEqual(0, clone.Items.Count);
        }
        [ProtoContract]
        public class SomeType
        {
            [ProtoMember(1)]
            public List<int> Items { get; set; }
        }
        [ProtoContract]
        public class SomeTypeSurrogate
        {
            [ProtoMember(1)]
            public List<int> Items { get; set; }
            [ProtoMember(2)]
            public bool ItemsIsEmpty { get; set; }
            public static implicit operator SomeTypeSurrogate(SomeType value)
            {
                return value != null
                    ? new SomeTypeSurrogate { Items = value.Items, ItemsIsEmpty = value.Items != null && value.Items.Count == 0 }
                    : null;
            }
            public static implicit operator SomeType(SomeTypeSurrogate value)
            {
                return value != null
                    ? new SomeType { Items = value.ItemsIsEmpty ? new List<int>() : value.Items }
                    : null;
            }
        }
