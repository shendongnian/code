    public partial class main : System.Web.UI.Page {
        protected void SendButton_Click(object sender, EventArgs e) {        
            Utility.SendExcelFile(this);
        }
    }
