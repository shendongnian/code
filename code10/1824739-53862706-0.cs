    private int? _number1;
    public string FirstArgument
    {
        get => _number1?.ToString();
        set
        {
            if (int.TryParse(value, out var number))
            {
                _number1 = number;
                OnPropertyChanged("FirstArgument");
            }
            else
            {
                _number1 = null;
            }
        }
    }
