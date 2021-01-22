    public class SchoolPage : Page
    {
      public void Page_Init(object sender, EventArgs e)
      {
        DataAccess dac = new  DataAccess();
        cmbEditSchool.DataSource = dac.GetSchoolData();
        cmbEditSchool.DataBind();
      }
    }
