    [DefaultProperty("Regex")]
    public partial class MaskedEdit : UserControl
    {
        private Regex regex = new Regex("");
        private bool myChange = false;
        private string goodText;
        private Font dataFont;
        public MaskedEdit()
        {
            myChange = true;
            InitializeComponent();
            myChange = false;
            dataFont = new Font(Font, FontStyle.Bold);
            goodText = Text;
        }
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", typeof(UITypeEditor)), Localizable(true)]
        [DefaultValue("")]
        public String Regex
        {
            get { return regex.ToString(); }
            set
            {
                if (value != null)
                {
                    regex = new Regex(value);
                }
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)] 
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design", typeof(UITypeEditor)), Localizable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return rtf.Text; }
            set {
                int selSt = rtf.SelectionStart;
                int selLen = rtf.SelectionLength;
                
                rtf.Text = value;
                
                rtf.SelectionStart = selSt;
                rtf.SelectionLength = selLen;
            }
        }
        private void rtf_TextChanged(object sender, EventArgs e)
        {
            if (myChange) return;
            Match m = regex.Match(Text);
            if (m.Success)
            {
                goodText = Text;
                Colorize(m);
            }
            else
            {
                myChange = true;
                Text = goodText;
                myChange = false;
                m = regex.Match(Text);
                if (m.Success)
                {
                    Colorize(m);
                }
            }
        }
        public IEnumerable<string> Data
        {
            get
            {
                Match m = regex.Match(Text);
                bool first = true;
                foreach (Group g in m.Groups)
                {
                    if (first) { first = false; continue; }
                    yield return Text.Substring(g.Index, g.Length);
                }
            }
        }
        private void Colorize(Match m)
        {
            int selSt = rtf.SelectionStart;
            int selLen = rtf.SelectionLength;
            rtf.SelectionStart = 0;
            rtf.SelectionLength = rtf.TextLength;
            rtf.SelectionFont = Font;
            bool first = true;
            foreach (Group g in m.Groups)
            {
                if (first) { first = false; continue; }
                rtf.SelectionStart = g.Index;
                rtf.SelectionLength = g.Length;
                rtf.SelectionFont = dataFont;
            }
            rtf.SelectionStart = selSt;
            rtf.SelectionLength = selLen;
        }
        private void MaskedEdit_FontChanged(object sender, EventArgs e)
        {
            dataFont = new Font(Font, FontStyle.Bold);
        }
    }
