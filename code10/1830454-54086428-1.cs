    [BindProperties]
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "Please enter user name.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
