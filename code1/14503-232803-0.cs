    StringBuilder builder = new StringBuilder();
    foreach (CheckBox cb in checkboxes)
    {
        if (cb.Checked)
        {
            builder.Append(cb.Text); // Or whatever
            builder.Append(Environment.NewLine); // "\r\n" or "\n"
        }
    }
    // Call Trim if you want to remove the trailing newline
    string result = builder.ToString();
