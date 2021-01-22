    public class Person
    {
        public int Id { get; set; }
 
        public string Firstname { get; set; }
 
        public string Surname { get; set; }
    }
 
    public class Address
    {
        public int Id { get; set; }
 
        public string AddressLine1 { get; set; }
 
        public string AddressLine2 { get; set; }
 
        public string Country { get; set; }
    }
 
    public class Comment
    {
        public string Text { get; set; }
 
        public DateTime Created { get; set; }
    }
 
