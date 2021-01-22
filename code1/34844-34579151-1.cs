        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class TinyMCE : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        // we have to tell the editor to re-save the date on Submit 
        if (!ScriptManager.GetCurrent(Page).IsInAsyncPostBack)
        {
          ScriptManager.RegisterOnSubmitStatement(this, this.GetType(), "SaveTextBoxBeforePostBack", "SaveTextBoxBeforePostBack()");
        }
    
      }
    
      protected void butSaveEditorContent_Click(object sender, EventArgs e)
      {
        string htmlEncoded = WebUtility.HtmlEncode(tbHtmlEditor.Text);
        
      }
    
      private void SaveToDb(string htmlEncoded)
      {
        /// save to database column
      }
    
      protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
      {
    
      }
    }
