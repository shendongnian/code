    public partial class dlgSample : Form {
        public dlgSample(bool isReadOnly) {
            InitializeComponent();
            if (isReadOnly) ZapMnemonics(this.Controls);
        }
        private void ZapMnemonics(Control.ControlCollection ctls) {
            foreach (Control ctl in ctls) {
                if (ctl is Label || ctl is Button) ctl.Text = ctl.Text.Replace("&", "");
                ZapMnemonics(ctl.Controls);
            }
        }
    }
