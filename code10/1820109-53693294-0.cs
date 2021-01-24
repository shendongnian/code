    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Car), typeof(Truck))]
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
