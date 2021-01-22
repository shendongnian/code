    public abstract class BasePerson
    {
        public abstract int ID { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string FullName { get { return FirstName + " " + LastName; } } 
    }
