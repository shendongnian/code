    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    
        public virtual StudentAddress Address { get; set; } //Can have only one address
    }
         
    public class StudentAddress 
    {
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    
        public virtual Student Student { get; set; }  //Single Student 
    }
