    public enum MyButtonLabelValue
    {
        On,
        Off
    }
    
    public class MyButton : Button
    {
        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                // either do nothing or only accept "On" and "Off". I know you're concerned about violating the 
                // contract, but that would be preferrable to not having a public .Text property at all
            }
        }
    
    
        public MyButtonLabelValue LabelValue 
        {
            get
            {
                return Text == "On" ? MyButtonLabelValue.On : MyButtonLabelValue.Off;
            }
            set
            {
                base.Text = value == MyButtonLabelValue.On ? "On" : "Off";
            }
        }
    }
