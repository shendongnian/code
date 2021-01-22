    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Phone> Phones { get; set; }
    }
    public class Phone
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
    }
