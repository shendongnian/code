    [DataContract(Name = "PatchObject")]
    class PatchObject
    {
        [DataMember(Name = "op")]
        public string Op { get; set; }
        [DataMember(Name = "path")]
        public string Path { get; set; }
        [DataMember(Name = "value")]
        public object Value { get; set; }
    }
