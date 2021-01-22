    [DataContract(
        Namespace = 
           "http://schemas.datacontract.org/2004/07/Whatever")]
    class Person
    {
        [DataMember]
        int Age { get; set; }
        Gender Gender { get; set; }
        [DataMember(Name = "Gender")]
        string GenderString
        {
            get { return this.Gender.ToString(); }
            set 
            { 
                Gender g; 
                this.Gender = Enum.TryParse(value, true, out g) ? g : Gender.Male; 
            }
        }
    }
