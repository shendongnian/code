    public class WebUserControl1 : System.Web.UI.UserControl
    {
       protected System.Web.UI.WebControls.Button Button1;
       protected System.Web.UI.WebControls.Panel Panel1;
    
       private void Page_Load(object sender, System.EventArgs e)
       {
          Response.Write("WebUserControl1 :: Page_Load <BR>");
       }
    
       private void Button1_Click(object sender, System.EventArgs e)
       {
          Response.Write("WebUserControl1 :: Begin Button1_Click <BR>");
          OnBubbleClick(e);
          Response.Write("WebUserControl1 :: End Button1_Click <BR>");
       }
    
       public event EventHandler BubbleClick;
    
       protected void OnBubbleClick(EventArgs e)
       {
          if(BubbleClick != null)
          {
             BubbleClick(this, e);
          }
       }           
    
       #region Web Form Designer generated code
       override protected void OnInit(EventArgs e)
       {
          InitializeComponent();
          base.OnInit(e);
       }
       
       private void InitializeComponent()
       {
          this.Button1.Click += new System.EventHandler(this.Button1_Click);
          this.Load += new System.EventHandler(this.Page_Load);
    
       }
       #endregion
    
    }
