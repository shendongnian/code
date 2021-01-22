    StringBuilder tags = new StringBuilder();
    // ...
    while (Data1.Read())
    {
        string tag = Data1.GetString(0);
        sb.Append(tag);
        sb.Append(",");  // Separator
    }
    lbl_tags.Text = tags.ToString();
