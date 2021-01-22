    public class ExtendedTabControl: TabControl
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Tab))
            {
                // Write custom logic here
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.Tab))
            {
                // Write custom logic here, for backward switching
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
