    public partial class TieableForm : Form
    {
        public TieableForm() { InitializeComponent(); }
        private Form Other { get; set; }
        public void Tie(Form other) =>
            Other = other;
        public void Untie() =>
            Other = null;
        private void button1_OnClick(object sender, EventArgs e) =>
            CloseBoth();
        private void CloseBoth()
        {
            if (Other != null)
                Other.Close();
            this.Close();
        }
    }
