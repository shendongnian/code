    var select = new HtmlSelect() { Size = 5 };
    
    //assuming the data has been placed in an IEnumarble
    foreach (var item in items)
    {
        select.Items.Add(new ListItem() { Value = item });
    }
    selectPlaceholder.Controls.Add(select);
