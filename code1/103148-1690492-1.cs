     protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack) {
           Clock c = new Clock();
           string display = c.GetCurrentTime().ToLongTimeString();
           this.Title = display;
           this.txtDate.Text = display;
         }
    
      }
    
      protected void btnRefresh_Click(object sender, EventArgs e)
      {
         Clock c = new Clock();
         string display = c.GetCurrentTime().ToLongTimeString();
         this.txtDate.Text = display;
      }
