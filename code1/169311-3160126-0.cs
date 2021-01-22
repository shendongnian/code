    [DataContract]
    public class MyClass
    {
        [DataMember]
        public string ScanDevice { get; set; }
        public MyClass()
        {
            SetDefaults();
        }
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            SetDefaults();
        }
        private void SetDefaults()
        {
            ScanDevice = "XeroxScan";
        }
    }
