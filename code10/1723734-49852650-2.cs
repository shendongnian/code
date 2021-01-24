    public class Member {
    
       public string FirstName { get; set; }
       public string LastName { get; set; }
    
       // foreign key for MembershipType 
       [ForeignKey("MembershipType")]
       public long MembershipTypeId { get; set; }
    
       public virtual MembershipType MembershipType { get; set; }
    }
