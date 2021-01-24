    public class Toy: BaseModel
    {
        [MaxLength(80)]
        public string Name { get; set; }
        [ForeignKey("AVUser")]
        public string UserId { get; set; }
        public AVUser AVUser { get; set; }
    
    }
    public class AVUser : IdentityUser
    {
        public string FirstName { get; set; }
    
        // The currently selected toy for the user.
        [ForeignKey("SelectedToy")]
        public int SelectedToyId { get; set; }
        public Toy SelectedToy { get; set; }
        public ICollection<Toy> Toys {get; set;}
    
    }
