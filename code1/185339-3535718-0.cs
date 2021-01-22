    [DataContract(Name = "root")]
    public class root
    {
        [DataMember]
        public List<resource> resources { get; set; }
        [DataMember]
        public myobject myobject { get; set; }
    }
    
    [DataContract]
    public class myobject
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public resource resource { get; set; }
    }
    
    [DataContract(Name = "resource", IsReference = true)]
    public class resource
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string anotherattribute { get; set; }
        [DataMember]
        public string content { get; set; }
    }
    ...
    var serializer = new DataContractSerializer(typeof(root));
    using (var xwriter = XmlWriter.Create(fileName))
    {
        serializer.WriteObject(xwriter, r);
    }
