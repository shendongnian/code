    public class RadioGroupBox : GroupBox
    {
        public event EventHandler SelectedChanged = delegate { };
        int _selected;
        public int Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                int val = 0;
                var radioButton = this.Controls.OfType<RadioButton>()
                    .FirstOrDefault(radio =>
                        radio.Tag != null 
                       && int.TryParse(radio.Tag.ToString(), out val) && val == value);
                if (radioButton != null)
                {
                    radioButton.Checked = true;
                    _selected = val;
                }
            }
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            var radioButton = e.Control as RadioButton;
            if (radioButton != null)
                radioButton.CheckedChanged += radioButton_CheckedChanged;
        }
        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            int val = 0;
            if (radio.Checked && radio.Tag != null 
                 && int.TryParse(radio.Tag.ToString(), out val))
            {
                _selected = val;
                SelectedChanged(this, new EventArgs());
            }
        }
    }
