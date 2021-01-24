    private string _F;
    public string F
    {
        get { return _F; }
        set
        {
            if (double.TryParse(value, out double dVal))
            {
                F = value;
                RaisePropertyChanged("F");
            }
            else
            {
                if (value.StartsWith("."))
                {
                    var fractions = value.Substring(1);
                    if (double.TryParse(fractions, out dVal))
                    {
                        F = value;
                        RaisePropertyChanged("F");
                    }
                }
            }
    
            // Use dVal here as needed.
        }
    }
