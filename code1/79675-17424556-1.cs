    namespace MyApplication.InterfaceSupport
    {
        public class NumericTextBox : TextBox
        {
            public NumericTextBox() : base()
            {
                TextChanged += OnTextChanged;
            }
            public void OnTextChanged(object sender, TextChangedEventArgs changed)
            {
                if (!String.IsNullOrWhiteSpace(Text))
                {
                    try
                    {
                        int value = Convert.ToInt32(Text);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(String.Format("{0} only accepts numeric input.", Name));
                        Text = "";
                    }
                }
            }
            public int? Value
            {
                set
                {
                    if (value != null)
                    {
                        this.Text = value.ToString();
                    }
                    else 
                        Text = "";
                }
                get
                {
                    try
                    {
                        return Convert.ToInt32(this.Text);
                    }
                    catch (Exception ef)
                    {
                        // Not numeric.
                    }
                    return null;
                }
            }
        }
    }
