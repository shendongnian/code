    public class ApplicationRolesViewModel
    {
        // Display Attribute will appear in the Html.LabelFor
        [Display(Name = "User Role")]
        public string RoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
