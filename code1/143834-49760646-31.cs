    public class MY_ATTACHMENT_TABLE_MODEL 
    {
        [Key]
        public byte[] File { get; set; }  // notice this change
        public string Name { get; set; }
        public string Type { get; set; }
    }
