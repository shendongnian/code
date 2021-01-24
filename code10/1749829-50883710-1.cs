    private string _F;
    public string F
    {
        get { return _F; }
        set
        {
            // See if the new value is a valid double.
            if (double.TryParse(value, out double dVal))
            {
                // If it is, set it and raise property changed.
                _F = value;
                RaisePropertyChanged("F");
            }
            else
            {
                // If not a valid double, see if it starts with a "."
                if (value.StartsWith("."))
                {
                    // If it does, then see if the rest of it is a valid double value.
                    // Here this is a minimal validation, to ensure there are no subsequent "."s, you'll need to do more validations.
                    var fractions = value.Substring(1);
                    if (double.TryParse(fractions, out dVal))
                    {
                        _F = value;
                        RaisePropertyChanged("F");
                    }
                }
            }
    
            // Use dVal here as needed.
        }
    }
