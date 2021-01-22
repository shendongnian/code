    public partial class Test_ : System.Web.UI.Page {
    
        protected void Button1_Click(object sender, EventArgs e) {
            if(ViewState["idx"] == null) {
                ViewState["idx"] = 0;
            }
            int idx = Convert.ToInt32(ViewState["idx"]);
            Button1.Text = (idx++).ToString();
            ViewState["idx"] = idx;
        }
    }
