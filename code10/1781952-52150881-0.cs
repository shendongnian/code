    // Start with the initial quote
    string sep = "'";
    StringBuilder sb = new StringBuilder();
    foreach(var l in label.Rows)
    {
        sb.Append(sep).Append(l.Text);
        // Quote before and after the comma
        sep = "','";
    }
    // You need an additional quote to close the string
    sb.Append("'");
     
