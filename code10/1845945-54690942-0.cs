public partial class TestPage : System.Web.UI.Page
    {
        string id = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
And now you can access it anywhere in your Code. 
protected void Button2_Click(object sender, EventArgs e)
{
    lblanything.Text = id;
}
protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
{
    GridViewRow row = GridView1.SelectedRow;
    id = row.Cells[3].Text;
}
