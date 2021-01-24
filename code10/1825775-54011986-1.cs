    public class RegisterViewModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
    
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            public string FullName
            {
                get
                {
                    return FirstName + " " + LastName;
                }
            }
    
            [Display(Name = "Superior")]
    
            public virtual ApplicationUser Superior { get; set; }
            
        } 
