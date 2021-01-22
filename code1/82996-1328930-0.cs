    public partial class NumberTextBox : TextBox
    {
        public NumberTextBox()
        {
            InitializeComponent();
        }
        public decimal Value
        {
            get
            {
                try
                {
                    return decimal.Parse(Text);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public int ValueInt
        {
            get { return int.Parse(Text); }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.' && (this).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
        public void AppendString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Text = string.Empty;
            }
            else
            {
                if (value == "." && Text.IndexOf('.') > -1)
                    return;
                Text += value;
            }
        }
    }
