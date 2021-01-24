    using System.Windows.Forms;
    public class MyTextBox : TextBox
    {
        public MyTextBox() { this.ReadOnly = true; }
        public new bool ReadOnly
        {
            get { return true; }
            set { base.ReadOnly = true; }
        }
        KeysConverter converter = new KeysConverter();
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            this.Text = converter.ConvertToString(keyData);
            return false;
        }
    }
