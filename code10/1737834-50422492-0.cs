    [DataContract]
    class Person 
    {
        [DataMember]
        public string Name {get; set; }
        [DataMember]
        public int Id {get; set; }
        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
