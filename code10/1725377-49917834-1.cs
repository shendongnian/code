    using System.Windows.Forms;
    public class MyTextBox : TextBox
    {
        public MyTextBox() { this.ReadOnly = true; }
        public Keys ShortcutKey { get; set; }
        public new bool ReadOnly
        {
            get { return true; }
            set { base.ReadOnly = true; }
        }
        KeysConverter converter = new KeysConverter();
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            ShortcutKey = keyData;
            this.Text = converter.ConvertToString(keyData);
            return false;
        }
    }
