      protected void Page_Init(object sender, EventArgs e) {
        textB = new TextBox();
        textB.ID = "dynamicTextC";
        Panel1.Controls.Add(textB);
      }
    
    
      protected void Page_Load(object sender, EventArgs e) {
        Label1.Text = textB.Text;
      }
    
    
