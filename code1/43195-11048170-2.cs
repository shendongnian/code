    public enum OptionEnum
    {
       Option1 = 0,
       Option2
    }
    OptionEnum _rbEnum = OptionEnum.Option1;
    OptionEnum PropertyRBEnum
    {
        get { return _rbEnum; }
        set
        {
            _rbEnum = value;
            RaisePropertyChanged("PropertyRBEnum");
        }
    }
    public static void FormatSelectedEnum<T>(object sender, ConvertEventArgs args) where T : struct
    {
        Binding binding = (sender as Binding);
        if (binding == null) return;
        Control button = binding.Control;
        if (button == null || args.DesiredType != typeof(Boolean)) return;
        T value = (T)args.Value;
        T controlValue;
        if (Enum.TryParse(button.Tag.ToString(), out controlValue))
        {
            args.Value = value.Equals(controlValue);
        }
        else
        {
            Exception ex = new Exception("String not found in Enum");
            ex.Data.Add("Tag", button.Tag);
            throw ex;
        }
    }
    public static void ParseSelectedEnum<T>(object sender, ConvertEventArgs args) where T : struct
    {
        Binding binding = (sender as Binding);
        if (binding == null) return;
        Control button = binding.Control;
        bool value = (bool)args.Value;
        if (button == null || value != true) return;
        T controlValue;
        if (Enum.TryParse(button.Tag.ToString(), out controlValue))
        {
            args.Value = controlValue;
        }
        else
        {
            Exception ex = new Exception("String not found in Enum");
            ex.Data.Add("Tag", button.Tag);
            throw ex;
        }
    }
