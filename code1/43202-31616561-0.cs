    public class RadioButtonGroupBox : GroupBox
    {
        public event EventHandler SelectedChanged = delegate { };
        int _nIndexPosCheckRadioButton = -1;
        int _selected;
        public int Selected
        {
            get
            {
                return _selected;
            }
        }
        public int CheckedRadioButtonIndexPos
        {
            set
            {
                int nPosInList = -1;
                foreach (RadioButton item in this.Controls.OfType<RadioButton>())
                {
                    // There are RadioButtonItems in the list...
                    nPosInList++;
                    // Set the RB that should be checked
                    if (nPosInList == value)
                    {
                        item.Checked = true;
                        // We can stop with the loop
                        break;
                    }
                }
                _nIndexPosCheckRadioButton = nPosInList;
            }
            get
            {
                int nPosInList = -1;
                int nPosCheckeItemInList = -1;
                foreach (RadioButton item in this.Controls.OfType<RadioButton>())
                {
                    // There are RadioButtonItems in the list...
                    nPosInList++;
                    // Find the RB that is checked
                    if (item.Checked)
                    {
                        nPosCheckeItemInList = nPosInList;
                        // We can stop with the loop
                        break;
                    }
                }
                _nIndexPosCheckRadioButton = nPosCheckeItemInList;
                return _nIndexPosCheckRadioButton;
            }
        }
        public string CheckedRadioButtonByText
        {
            set
            {
                int nPosInList = -1;
                foreach (RadioButton item in this.Controls.OfType<RadioButton>())
                {
                    // There are RadioButtonItems in the list...
                    nPosInList++;
                    // Set the RB that should be checked
                    if (item.Text == value)
                    {
                        item.Checked = true;
                        // We can stop with the loop
                        break;
                    }
                }
                _nIndexPosCheckRadioButton = nPosInList;
            }
            get
            {
                string cByTextValue = "__UNDEFINED__";
                int nPosInList = -1;
                int nPosCheckeItemInList = -1;
                foreach (RadioButton item in this.Controls.OfType<RadioButton>())
                {
                    // There are RadioButtonItems in the list...
                    nPosInList++;
                    // Find the RB that is checked
                    if (item.Checked)
                    {
                        cByTextValue = item.Text;
                        nPosCheckeItemInList = nPosInList;
                        // We can stop with the loop
                        break;
                    }
                }
                _nIndexPosCheckRadioButton = nPosCheckeItemInList;
                return cByTextValue;
            }
        }
        public string CheckedRadioButtonByName
        {
            set
            {
                int nPosInList = -1;
                foreach (RadioButton item in this.Controls.OfType<RadioButton>())
                {
                    // There are RadioButtonItems in the list...
                    nPosInList++;
                    // Set the RB that should be checked
                    if (item.Name == value)
                    {
                        item.Checked = true;
                        // We can stop with the loop
                        break;
                    }
                }
                _nIndexPosCheckRadioButton = nPosInList;
            }
            get
            {
                String cByNameValue = "__UNDEFINED__";
                int nPosInList = -1;
                int nPosCheckeItemInList = -1;
                foreach (RadioButton item in this.Controls.OfType<RadioButton>())
                {
                    // There are RadioButtonItems in the list...
                    nPosInList++;
                    // Find the RB that is checked
                    if (item.Checked)
                    {
                        cByNameValue = item.Name;
                        nPosCheckeItemInList = nPosInList;
                        // We can stop with the loop
                        break;
                    }
                }
                _nIndexPosCheckRadioButton = nPosCheckeItemInList;
                return cByNameValue;
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
            _selected = CheckedRadioButtonIndexPos;
            SelectedChanged(this, new EventArgs());
        }
    }
