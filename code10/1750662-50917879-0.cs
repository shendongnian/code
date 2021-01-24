    [Table("searchprofilepush")]
    public class SearchProfilePush
    {
       [Key]
       public int Id { get; set; }
       public int AccountId { get; set; }
       public bool Push { get; set; }
       public int UserPushId { get; set; }
       public UserPush UserPush { get; set; }
       public int SearchProfileId { get; set; }
       public SearchProfile SearchProfile { get; set; }
       public ICollection<SearchProfileMediaTypePush> SearchProfileMediaTypePush { get; set; }
    }
    
    
    [Table("searchprofilemediatypepush")]
    public class SearchProfileMediaTypePush
    {
       [Key]    
       public int Id { get; set; }
       public MediaTypeType MediaType { get; set; }
       public bool Push { get; set; }
       public int SearchProfilePushId { get; set; }
       [ForeignKey("SearchProfilePushId")]     
       public SearchProfilePush SearchProfilePush { get; set; }
    }
