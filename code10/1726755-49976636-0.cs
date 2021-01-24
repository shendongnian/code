    protected void Page_Load()
    
        {
          Button ButtonChange = new Button();
        
          ButtonChange.Text = "New Button";
          ButtonChange.ID = "btnNew_" + i.ToString();
          ButtonChange.Font.Size = FontUnit.Point(7);
          ButtonChange.ControlStyle.CssClass = "button";
          ButtonChange.Click += new EventHandler(test);
        }
