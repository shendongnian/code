    foreach (Control c in TabEditor.Controls)
    {
        // c will be a TabPage
        foreach (Control childc in c.Controls)
        {
            // childc is a control inside TabPage, e.g GroupBox
            foreach (NumericUpDown nud in childc.Controls.OfType<NumericUpDown>())
            {
                nud.Increment = (decimal)NumericIncrementPrecision.Value;
            }
        }
    }
