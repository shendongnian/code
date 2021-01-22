    public class HasBinaryProperty
    {
        public byte[] versionBytes;
    
        public HasBinaryProperty()
        {//ignore this used it to test the serialization of the class briefly
            Random rand = new Random();
            byte[] bytes = new byte[20];
            rand.NextBytes(bytes);
            this.VersionNumber = new Binary(bytes);
        }
    
        [XmlIgnore]
        public Binary VersionNumber
        {
            get
            {
                return new Binary(this.versionBytes);
            }
            set
            {
                this.versionBytes = value.ToArray();
            }
        }
    }
