    using System;
    using System.ComponentModel.DataAnnotations;
    namespace MyProject.Models
    {
        public class Tab
        {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Tab Name")]
            public string TabName { get; set; }
            [Display(Name = "Name")]
            public string UserName { get; set; }
            [Display(Name = "Email")]
            public string UserEmail { get; set; }
            [Display(Name = "Created")]
            public DateTime? CreatedAt { get; set; }
            [Display(Name = "Filter String")]
            public string FilterString { get; set; }
        }
    }
