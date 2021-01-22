    HtmlSelect select = new HtmlSelect();
    select.ID = "AutoGenSelect";
    select.Items.Add(new ListItem("Item1", "1"));
    select.Items.Add(new ListItem("Item2", "2"));
    select.Items.Add(new ListItem("Item3", "3"));
    
    // Retreive the last selected value.
    select.Value = Request["AutoGenSelect"] ?? "1";
    
    Panel1.Controls.Add(select);
