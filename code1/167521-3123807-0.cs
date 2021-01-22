    public class Patient
    {
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string InitialsAndLastName
        {
            get { return this.Initials + " " + this.LastName; }
        }
    }
