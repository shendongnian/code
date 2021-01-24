    using System;
    using System.ComponentModel.DataAnnotations;
    
    namespace CApp.Data
    {
    
        [MetadataType(typeof(ConsultantMetaData))]
        public partial class Consultant
        {
        }
        public class ConsultantMetaData
        {
            [Required]
            [Display(Name = "Name")]
            public string ConsultantName { get; set; }
    
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string ConsultantEmail { get; set; }
    
            [Required]
            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }
        }
    }
