    public class NumericUpDownNew : NumericUpDown
    {
        public new decimal Value
        {
            get { return base.Value; }
            set 
            {
                string text = "";
                if(this.ThousandsSeparator)
                    text = ((decimal)value).ToString("n" + this.DecimalPlaces);
                else
                    text = ((decimal)value).ToString("g" + this.DecimalPlaces);
                Controls[1].Text = text;
                base.Value = value;
            }
        }
    }
