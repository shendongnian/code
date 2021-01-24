    public class NewRoleViewModel
    {
        //[Required] // no-longer required so that users can submit empty lists
        [Display(Name="Name" )]
        public String NewRoleName { get; set; }
    }
    public class ApplicationRoleModel : ClaimsToRoleModel
    {
        [BindNever] // BindNever is to avoid model-binding security issues
        public IEnumerable<ApplicationRole> RoleList { get; set; }
        [Required]
        public List<NewRoleViewModel> NewRoles { get; } = new List<NewRoleViewModel>();
    }
