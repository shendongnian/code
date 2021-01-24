    public abstract class ModelBase
    {
        [BsonIgnore]
        public virtual int Duration { get; set; }
        [BsonIgnore]
        public virtual DateTime EndDate { get; set; }
        [BsonIgnore]
        public virtual DateTime StartDate { get; set; }
    }
