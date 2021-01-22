    public class BasePage : Page{
      protected virtual Label ErrorLabel { get; set; };
      protected override OnLoad(object sender, EventArgs e) {
        base.OnLoad(sender, e);
        const int maxFileSizeKBytes = 10240; //10 MB
        const int maxRequestSizeKBytes = 305200; //~298 MB
        if (Request.ContentLength > (maxRequestSizeKBytes * 1024))
        {
            ErrorLabel.Text = "Request length "+Request.ContentLength+" was too long."
            ErrorLabel.Visible = true;
        }
        for (int i = 0; i < Request.Files.Count; i++)
        {
            if (Request.Files[i].ContentLength > (maxFileSizeKBytes * 1024))
            {
                ErrorLabel.Text = "File length "+ Request.Files[i].ContentLength +" was too long."
                ErrorLabel.Visible = true;
            }
        }
      }
    }
    
    public class ViewProject : BasePage {
      protected override Label ErrorLabel {
        get { return LocalErrorLabel; } // something defined in HTML template
        set { throw new NotSupportedException(); }
      }
    }
