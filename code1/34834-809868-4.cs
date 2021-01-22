    using System.Web.UI;
    
    namespace TinyMCEProblemDemo
    {
        public partial class EditorClean : UserControl
        {
            protected void Page_Load(object sender, System.EventArgs e)
            {                
                  ScriptManager.RegisterStartupScript(this.Page, 
                      this.Page.GetType(), mce.ClientID, "callInt" + mce.ClientID + "();", true);
            }
        }
    }
