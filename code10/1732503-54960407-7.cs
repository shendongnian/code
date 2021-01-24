    [DataContract(Name ="Node")]
    public class Node
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    
        [DataMember(Name = "node_id")]
        public int Node_id { get; set; }
    
        [DataMember(Name = "name")]
        public string Name { get; set; }
    
        [DataMember(Name = "full_name")]
        public string Full_name { get; set; }
    }
