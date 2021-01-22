    StringBuilder builder = new StringBuilder();
    foreach (CheckBox cb in checkboxes)
    {
        if (cb.Checked)
        {
            builder.AppendLine(cb.Text); // Or whatever
        }
    }
    // Call Trim if you want to remove the trailing newline
    string result = builder.ToString();
