    TextWriter myTextWriter = new StringWriter();
    HtmlTextWriter myWriter = new HtmlTextWriter(myTextWriter);
    
    UserControl myDuplicate = new UserControl();
    TextBox blankTextBox;
    
    foreach (Control tmpControl in this.Controls)
    {
        switch (tmpControl.GetType().ToString())
        {
            case "System.Web.UI.LiteralControl":
                blankLiteral = new LiteralControl();
                blankLiteral.Text = ((LiteralControl)tmpControl).Text;
                myDuplicate.Controls.Add(blankLiteral);
                break;
            case "System.Web.UI.WebControls.TextBox":
                blankTextBox = new TextBox();
                blankTextBox.ID = ((TextBox)tmpControl).ID;
                blankTextBox.Text = ((TextBox)tmpControl).Text;
                myDuplicate.Controls.Add(blankTextBox);
                break;
                // ...other types of controls (ddls, checkboxes, etc.)
        }
    }
    
    myDuplicate.RenderControl(myWriter);
    return myTextWriter.ToString();
