    public class EditUserViewModel
        {
            public int Id { get; set; }
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
            public int? SuperiorID { get; set; }
    
            public virtual ApplicationUser Superior { get; set; }
            
        } 
