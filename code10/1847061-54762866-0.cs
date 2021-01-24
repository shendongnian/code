     public class ApplicationRole:IdentityRole
    {
        public string Location { get; set; }//add the stuff you want
        public ApplicationUser ApplicationUser { get; set; }
    }
