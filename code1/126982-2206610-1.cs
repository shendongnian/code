    namespace SO
    {
        using System;
        using System.Web.UI;
        using System.Web.UI.WebControls;
    
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Page.IsPostBack)
                {
                    // we have our file name but not the file
                    this.form1.Controls.Add(new Literal() { Text = this.FilePath.Value });
                    System.Diagnostics.Debug.Assert(this.FileUpload1.PostedFile == null);
                }
            }
        }
    }
