    public class Address
    {
       public int StudentId { get; set; } // Here StudentId is the PrimaryKey and ForeignKey at the same time.
       public string Street{ get; set; }
    
       public Student Student { get; set; }
    }
