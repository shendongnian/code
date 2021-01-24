    public class Node
    {
        [BsonElement("_id")]
        public long Id { get; set; }
    
        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; }
    
        [BsonElement("tags")]
        public BsonDocument Tags { get; set; }
    }
