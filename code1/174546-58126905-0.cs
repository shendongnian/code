    // these methods only works on rows that are set to AutoSize
    public static class TableLayoutPanelExtensions
    {
        public static void HideRows(this TableLayoutPanel panel, params int[] rowNumbers)
        {
            foreach (Control c in panel.Controls)
            {
                if (rowNumbers.Contains(panel.GetRow(c)))
                    c.Visible = false;
            }
        }
        public static void ShowRows(this TableLayoutPanel panel, params int[] rowNumbers)
        {
            foreach (Control c in panel.Controls)
            {
                if (rowNumbers.Contains(panel.GetRow(c)))
                    c.Visible = true;
            }
        }
    }
