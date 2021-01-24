    [XmlRoot(ElementName = "registrations")]
    public class Registrations
    {
        [XmlIgnore]
        public int CountAttendances
        {
            get
            {
                if (registrationList == null)
                {
                    return 0;
                }
                int count = registrationList.Count(x => x.attendingSocialEvent.Equals("yes", StringComparison.OrdinalIgnoreCase));
                return count;
            }
        }
        [XmlElement(ElementName = "Registration")]
        public List<Registration> registrationList { get; set; }
        public Registrations()
        {
            this.registrationList = new List<Registration>();
        }
    }
