    public partial class ContactDetail
    {
       //other properties
        [JsonIgnore]
        public virtual Manager Manager { get; set; }
    }
