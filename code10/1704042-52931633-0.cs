    private ValidatableObject<string> _myValue;
    public ViewModel()
    {
      _myValue = new ValidatableObject<string>();
      _myValue.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A value is required." });
    }
    public ValidatableObject<string> MyValue
    {
      get { return _myValue; }
      set
      {
          _myValue = value;
          OnPropertyChanged(nameof(MyValue));
      }
    }
    public ICommand ValidateValueCommand => new Command(() => ValidateValue());
    private bool ValidateValue()
    {
      return _myValue.Validate(); //updates ValidatableObject.Errors
    }
