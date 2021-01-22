    internal static void changeControlColour(Control f, Color color)
    {
        foreach (Control c in f.Controls)
        {
            // MessageBox.Show(c.GetType().ToString());
            if (c.HasChildren)
            {
                changeControlColour(c, color);
            }
            else
                if (c is Label)
                {
                    Label lll = (Label)c;
                    lll.ForeColor = color;
                }
        }
    }
