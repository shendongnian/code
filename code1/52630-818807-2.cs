    internal partial class InputBoxForm : Form
    {
        Size lbltextoriginalsize;
        Size pnlwhiteoroginalsize;
        public InputBoxForm(string text, string defaultvalue, string caption)
        {
            InitializeComponent();
            this.pnlWhite.Resize += new System.EventHandler(this.pnlWhite_Resize);
            this.lblText.Resize += new System.EventHandler(this.lblText_Resize);
            picIcon.Image = SystemIcons.Question.ToBitmap();
            lbltextoriginalsize = lblText.Size;
            pnlwhiteoroginalsize = pnlWhite.Size;
            this.lblText.Text = text;
            this.txtOut.Text = defaultvalue;
            this.Text = caption;
        }
        private void lblText_Resize(object sender, EventArgs e)
        {
            pnlWhite.Size += lblText.Size - lbltextoriginalsize;
        }
        private void pnlWhite_Resize(object sender, EventArgs e)
        {
            this.Size += pnlWhite.Size - pnlwhiteoroginalsize;
        }
        public string Value
        {
            get { return txtOut.Text; }
        }
    }
    /// <summary>
    /// A counterpart to the MessageBox class, designed to look similar (at least on Vista)
    /// </summary>
    public static class InputBox
    {
        public static DialogResult Show(string text, out string result)
        {
            return ShowCore(null, text, null, null, out result);
        }
        public static DialogResult Show(IWin32Window owner, string text, out string result)
        {
            return ShowCore(owner, text, null, null, out result);
        }
        public static DialogResult Show(string text, string defaultValue, out string result)
        {
            return ShowCore(null, text, defaultValue, null, out result);
        }
        public static DialogResult Show(IWin32Window owner, string text, string defaultValue, out string result)
        {
            return ShowCore(owner, text, defaultValue, null, out result);
        }
        public static DialogResult Show(string text, string defaultValue, string caption, out string result)
        {
            return ShowCore(null, text, defaultValue, caption, out result);
        }
        public static DialogResult Show(IWin32Window owner, string text, string defaultValue, string caption, out string result)
        {
            return ShowCore(owner, text, defaultValue, caption, out result);
        }
        private static DialogResult ShowCore(IWin32Window owner, string text, string defaultValue, string caption, out string result)
        {
            InputBoxForm box = new InputBoxForm(text, defaultValue, caption);
            DialogResult retval = box.ShowDialog(owner);
            result = box.Value;
            return retval;
        }
    }
