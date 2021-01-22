    public partial class DropdownTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllCoursesToDDL();
            }
        }
    
        private List<Course> GetDummyCourses()
        {
            return new List<Course>{
                new Course{ CourseCode = "A12", CourseName = "Introduction to Programming"},
                new Course{ CourseCode = "B112", CourseName = "Theory of Computing"}
            };
        }
    
        private void LoadAllCoursesToDDL()
        {
            this.coursesDropDownList1.Items.Clear();
    
            List<Course> items = GetDummyCourses();
    
            this.coursesDropDownList1.DataSource = items;
            this.coursesDropDownList1.DataTextField = "CourseName";
            this.coursesDropDownList1.DataValueField = "CourseCode";
            this.coursesDropDownList1.DataBind();
        }
    
        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Server.Transfer("~/Teacher/TeacherControlPanel.aspx?username=" + username);
        }
    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string code = coursesDropDownList1.SelectedItem.Value;
            string code2 = coursesDropDownList1.SelectedValue;
        }
    }
    
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
