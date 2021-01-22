    public partial class IntegerBox : TextBox 
    {
        public IntegerBox()
        {
            InitializeComponent();
            this.Text = 0.ToString();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        private String originalValue = 0.ToString();
        private void Integerbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            originalValue = this.Text;
        }
        private void Integerbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(this.Text))
                {
                    this.Text = 0.ToString();
                }
                this.Text = Convert.ToInt64(this.Text.Trim()).ToString();
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Value entered is to large max value: " + Int64.MaxValue.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = originalValue;
            }
            catch (System.FormatException)
            {                
                this.Text = originalValue;
            }
            catch (System.Exception ex)
            {
                this.Text = originalValue;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }       
    }
