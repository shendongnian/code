    using System.ComponentModel.DataAnnotations;
    public class Purchase
    {
        public int Id { get; set; }
        // others
        
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    } 
