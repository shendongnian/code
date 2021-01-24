    public class ApplicationRoleModel : ClaimsToRoleModel
    {
        [BindNever] // BindNever is to avoid model-binding security issues
        public IEnumerable<ApplicationRole> RoleList { get; set; }
        [Required]
        [Display( "Name" )] // This will be displayed in the `<label asp-for>` element
        public String NewRoleName { get; }
    }
