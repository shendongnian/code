    [DataContract]
    public class Employer
    {
        [DataMember(Name = "Id", IsRequired=false, EmitDefaultValue=false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    
