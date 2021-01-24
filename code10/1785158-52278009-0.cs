    var listButton = new List<Button> {button1, button2, ...}
    
    switch (status)
    {
        case "1":
           listButton.ForEach(b => b.Visible = true);
           Panel1.Visible = true;
           break;
        case "2":
           listButton.ForEach(b => b.Visible = true);
           Panel2.Visible = true;
           break;
    }
