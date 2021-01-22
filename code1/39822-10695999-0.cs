    public List<Person> People { get; set; }
    [DataMember(Name = "People")]
    public Person[] Persons {
        get {
            return People.ToArray();
        }
        private set { }
    }
