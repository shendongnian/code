    public partial class DropDownExample : System.Web.UI.Page
    {
        protected int GetMaxLength(string passedValue)
        {
            //could check passedValue to determine length from database not shown
            //kudos https://forums.asp.net/t/1274891.aspx?Textbox+maxlength+using+variable
            return 10;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //you need this if you want to do it this way
            //you could just set the maxlength on control in codebehind
            txtProduct.DataBind();
        }
    }
