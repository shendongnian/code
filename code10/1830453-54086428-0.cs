        [BindProperty]
        [Required(ErrorMessage = "Please enter user name.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
