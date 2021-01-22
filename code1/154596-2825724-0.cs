    public class Entity1
    {
        public Entity1()
        {
            Guid = System.Guid.NewGuid();
        }
        [Column(IsDbGenerated = true)]
        public Guid Bssid { get; set; }
        [Column(IsPrimaryKey = true, IsDbGenerated = false, Name = "Guid")]
        public Guid? Guid { get; set; }
        // other properties
        [Column(AutoSync = AutoSync.OnInsert , DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int NewSslid { get; set; }
     }
