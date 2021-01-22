    public class PersonViewModel
    {
        public int Id { get; set; }
 
        [DisplayName("Firstname")]
        public string Firstname { get; set; }
 
        [DisplayName("Surname")]
        public string Surname { get; set; }
 
        [DisplayName("Address Line 1")]
        public string AddressLine1 { get; set; }
 
        [DisplayName("Address Line 2")]
        public string AddressLine2 { get; set; }
 
        [DisplayName("Country Of Residence")]
        public string Country { get; set; }
 
        [DisplayName("Admin Comment")]
        public string Comment { get; set; }
 
    }
 
