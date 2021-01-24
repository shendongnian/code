    //Defining id as Static
    
    public partial class MyPage: System.Web.UI.Page
    {
    
           static string id = String.Empty;
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
     }
    
    //Setting the Static variable to a value
    
    protected void MyGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        GridViewRow row = MyGridView.SelectedRow;
    
        id = row.Cells[3].Text;
    
    }
    
    //Assigning the Static variable
    
    protected void MyButton_Click(object sender, EventArgs e)
    {
    
        lable1.Text = id;
    
    }
