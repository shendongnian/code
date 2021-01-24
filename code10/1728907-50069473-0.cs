    public class MyEntity
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string SomeStringProperty { get; set; }
        public DateTime SomeDateTimeProperty { get; set; }
    }
