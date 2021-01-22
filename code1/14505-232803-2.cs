    StringBuilder builder = new StringBuilder();
    foreach (CheckBox cb in checkboxes)
    {
        if (cb.Checked)
        {
            builder.AppendLine(cb.Text); // Or whatever
            // Alternatively:
            // builder.Append(cb.Text);
            // builder.Append(Environment.NewLine); // Or a different line ending
        }
    }
    // Call Trim if you want to remove the trailing newline
    string result = builder.ToString();
