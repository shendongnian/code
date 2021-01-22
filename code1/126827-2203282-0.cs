    var cntrls = new List<WebControl>()
            {
                {new TextBox(){ID = "Textbox1"}},
                {new Button(){ID="Button1", Text = "Click me!"}}
            };
    
    cntrls.ForEach(x => x.Enabled = false);
