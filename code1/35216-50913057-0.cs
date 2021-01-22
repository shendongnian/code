    internal class DataItem
    {
        private static Color originalBackColor, changedBackColor, originalForeColor, changedForeColor;
        private static Font originalFont, changedFont;
        static DataItem()
        {
            originalBackColor = SystemColors.Control;
            changedBackColor = SystemColors.HighlightText;
            originalForeColor = Color.Black;
            changedForeColor = Color.Red;
            originalFont = new Font(FontFamily.GenericSansSerif, 12.5f);
            changedFont = new Font(originalFont, FontStyle.Bold);
        }
        public static void ChangeSetup(Control original, Color changedBackgroundColor)
        {
            originalBackColor = original.BackColor;
            originalForeColor = original.ForeColor;
            originalFont = original.Font;
            changedBackColor = changedBackgroundColor;
            changedFont = new Font(originalFont, FontStyle.Bold);
        }
        private bool changeTracking;
        public DataItem(Control control, Object value)
        {
            this.Control = control;
            var current = String.Format("{0}", Control.Text).Trim();
            if (Control is ComboBox)
            {
                var cbo = (ComboBox)Control;
                current = cbo.StateGet();
            }
            this.OriginalValue = current;
            this.Control.TextChanged += Control_TextChanged;
            changeTracking = true;
        }
        public Control Control { get; private set; }
        private void Control_TextChanged(Object sender, EventArgs e)
        {
            if (TrackingChanges)
            {
                if (HasChanged)
                {
                    this.Control.BackColor = originalBackColor;
                    this.Control.Font = originalFont;
                    this.Control.ForeColor = originalForeColor;
                }
                else
                {
                    this.Control.BackColor = changedBackColor;
                    this.Control.Font = changedFont;
                    this.Control.ForeColor = changedForeColor;
                }
            }
        }
        public bool HasChanged
        {
            get
            {
                var current = String.Format("{0}", Control.Text).Trim();
                if (Control is ComboBox)
                {
                    var cbo = (ComboBox)Control;
                    current = cbo.StateGet();
                }
                return !current.Equals(OriginalValue);
            }
        }
        public String OriginalValue { get; private set; }
        public void Reset()
        {
            changeTracking = false;
            this.OriginalValue = String.Empty;
            this.Control.Text = String.Empty;
            this.Control.BackColor = originalBackColor;
            this.Control.Font = originalFont;
            this.Control.ForeColor = originalForeColor;
        }
        public bool TrackingChanges
        {
            get
            {
                return changeTracking;
            }
        }
    }
