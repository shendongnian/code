    public partial class MyNumericUpDown : NumericUpDown
    {
        public override string Text
        {
            get
            {
                if (base.Text.Length == 0)
                {
                    return "0";
                }
                else
                {
                    return base.Text;
                }
            }
            set
            {
                if (value.Equals("0"))
                {
                    base.Text = "";
                }
                else
                {
                    base.Text = value;
                }
            }
        }
    }
