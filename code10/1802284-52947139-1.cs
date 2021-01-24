    foreach (DataGridViewRow row in sJDataGridView.Rows)
    {
        bool a = Convert.ToBoolean(row.Cells[14].Value);
        bool b = Convert.ToBoolean(row.Cells[15].Value);
        bool c = Convert.ToBoolean(row.Cells[16].Value);
        if (a == true && b == false && c == false)
            viewModeColour = Color.FromArgb(0xE3F7FF); // Blue
        if (a == false && b == false && c == false)
            viewModeColour = Color.FromArgb(0xFFFDCC); // Yellow
        if (a == true && b == true && c == false)
            viewModeColour = Color.FromArgb(0xFF8787); // Red
        if (a == true && b == false && c == true)
            viewModeColour = Color.FromArgb(0xE5FFCC); // Green
        viewModeColourRGB = Color.FromArgb(viewModeColour.R, viewModeColour.G, viewModeColour.B);
        row.DefaultCellStyle.BackColor = viewModeColourRGB;
    }
