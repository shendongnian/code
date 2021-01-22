    public class WebForm1 : System.Web.UI.Page
    {
       protected WebUserControl1 BubbleControl;
    
       private void Page_Load(object sender, System.EventArgs e)
       {
          Response.Write("WebForm1 :: Page_Load <BR>");
       }
    
       #region Web Form Designer generated code
       override protected void OnInit(EventArgs e)
       {
          InitializeComponent();
          base.OnInit(e);
       }
       
       private void InitializeComponent()
       {    
          this.Load += new System.EventHandler(this.Page_Load);
          BubbleControl.BubbleClick += new EventHandler(WebForm1_BubbleClick);
       }
       #endregion
    
       private void WebForm1_BubbleClick(object sender, EventArgs e)
       {
          Response.Write("WebForm1 :: WebForm1_BubbleClick from " + 
                         sender.GetType().ToString() + "<BR>");         
       }
    }
