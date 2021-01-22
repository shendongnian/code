    public enum RadioButtonEnum
    {
       Option1 = 0,
       Option2
    }
    RadioButtonEnum _rbEnum = RadioButtonEnum.Option1;
    RadioButtonEnum PropertyRBEnum
    {
        get { return _rbEnum; }
        set
        {
            _rbEnum = value;
            RaisePropertyChanged("PropertyRBEnum");
        }
    }
    void FormatSelectedRadioButton<T>(object sender, ConvertEventArgs args) where T : struct
    {
        if (args.DesiredType == typeof(System.Boolean))
        {
            T value = (T)args.Value;
            T controlValue;
            if (Enum.TryParse<T>(((sender as Binding).Control as RadioButton).Tag.ToString(), out controlValue))
            {
                args.Value = value.Equals(controlValue);
            }
            else
            {
                // exception | message
            }
        }
    }
    private void OnRadioButtonCheckedChanged(object sender, EventArgs e)
    {
        RadioButton btn = sender as RadioButton;
        if (btn.Checked)
        {
            RadioButtonEnum controlValue;
            if (Enum.TryParse<RadioButtonEnum>(btn.Tag.ToString(), out controlValue))
            {
                PropertyRBEnum = controlValue;
            }
            else
            {
                // exception | message
            }
        }
    }
