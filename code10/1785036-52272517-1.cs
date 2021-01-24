    // serialize me.
    class Data
    {
        public virtual string Filename { get; set; }
    }
    // deserialize me.
    [DataContract]
    class IncomingData : Data
    {
        [DataMember(Name = "$Filename")]
        public override string Filename { get => base.Filename; set => base.Filename = value; }
    }
