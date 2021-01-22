    [DataContract(IsReference=true)]
    public class Contact
    {
        Company parentCompany;
        [DataMember]
        public Company ParentCompany
        {
            get { return parentCompany; }
            set { parentCompany = value; }
        }
        string fullName;
        [DataMember]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
    }
    [DataContract(IsReference = true)]
    public class Company
    {
        string name;
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        List<Contact> contacts = new List<Contact>();
        [DataMember]
        public List<Contact> Contacts
        {
            get { return contacts; }
        }
    }
