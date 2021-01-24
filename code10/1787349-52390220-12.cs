    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace WebApplication.Models
    {
        public class Mytable
        {
            // This generate a String ID
            // No ID modification needed for providers
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string Id { get; set; }
    
            // ....
        }
    }
