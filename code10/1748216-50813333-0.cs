    public partial class UserLogin
    {
        [Key]
        [Column(Order=1)]
        public string LoginProvider {get; set;}
        [Key]
        [Column(Order=2)]
        public string ProviderKey {get; set; }
        // and so on...
    }
