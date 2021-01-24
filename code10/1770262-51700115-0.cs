    public class PersonalInfo 
    {
        public FName { get; private set; }
        public LName { get; private set; }
        public MName { get; private set; }
        public Address { get; private set; }
        public PersonalInfo (string info)
        {
            string[] items = info.Split(',');
            FName = items [0];
            MName = items [1];
            LName = items [2];
            Address = items [3];
        }
       
        public override ToString()
        {
            return $"{LName}, {FName} {MName}"; 
        }
    }
