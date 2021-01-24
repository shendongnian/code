    public class ApplicationUser : IdentityUser
    {
         // Because it is derived, all existing AspNetUser columns are inherited
         // just need to add your new columns
         public int DepartmentId { get; set; }
    }
    // model used for login page - with validation within page for items
    public class LoginViewModel()
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<SelectListItem> DepartmentList {
           get {return new List<SelectListItem>() { 
                new SelectListItem() {Text = "Department A", Value = "1"},
                new SelectListItem() {Text = "Department B", Value = "2"},
                new SelectListItem() {Text = "Department C", Value = "3"}
             };
        }
        private int selectedDepartment { 
            return DepartmentList.SelectedValue != null ? 
                   Convert.Int32(DepartmentList.SelectedValue) : -1;
        }
    }
