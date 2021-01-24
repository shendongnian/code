    public class Users
    {
        [Required]
        [StringLength(6, MinimumLength = 3)]
       //[Display(Name = "User Name")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed")]
        [ScaffoldColumn(false)]
        public string UserName { get; set; }
        [Required]
      //  [Display(Name = "Password")]
        private string _AuthenticatedToken ;
        public string Password { get; set; }
        public string UserID { get; set; }
        public string val { get; set; }
        public string Test { get; set; }
        public string AuthenticatedToken {
            get {
                    return _AuthenticatedToken;
                }
        }
        public bool AuthenticateUser() 
        {
            SISInterfaceBus objSISInterfaceBus = new SISInterfaceBus();
            SISValidateUserResultSet objSISValidateUserResultSet = objSISInterfaceBus.ValidateLogin(this.UserName,this.Password);
            _AuthenticatedToken = objSISValidateUserResultSet.SISAuthToken;
            return objSISValidateUserResultSet.IsValidUser;
        }
    }
  
