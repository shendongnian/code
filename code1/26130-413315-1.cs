    override protected void OnInit(EventArgs e)
    {
      this.Load += new System.EventHandler(this.Page_Load);
      this.myButton.Click += new System.EventHandler(this.myButton_Click);
    
      base.OnInit(e);
    }
