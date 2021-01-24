    public class User
    {      
      public int IdUser { get; set; }
      public string UserName { get; set; }
      public bool Validate { get; set; } 
      public int? PartnerId { get; set; }
      public User Partner { get; set; }
      public ICollection<User> PartnerUsers{ get; set;}       
    }
