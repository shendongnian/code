    protected override void OnInit(EventArgs e)
    {
        
        string dynamicControlId = "MyControl";
                
        TextBox textBox = new TextBox {ID = dynamicControlId};
        placeHolder.Controls.Add(textBox);
    }
