    public partial class SpecialNumericUpDown : NumericUpDown
    {
        public SpecialNumericUpDown()
        {
            InitializeComponent();
        }
        protected override void UpdateEditText()
        {
            if (this.Value != 0)
            {
                base.UpdateEditText();
            }
            else
            {
                base.Controls[1].Text = "";
            }
        }
    }
