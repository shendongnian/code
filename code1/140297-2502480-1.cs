    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    
        public override bool Equals(object obj)
        {
            if (obj as Address == null)
                return false;
            return ((Address) obj).AddressLine1.Equals(AddressLine1);
        }
    }
