    public ViewModelBase()
    {
        PropertyInfo[] properties = GetType().GetProperties();
        foreach (PropertyInfo property in properties)
        {
            var attrs = property.GetCustomAttributes(true);
            if (attrs?.Length > 0)
            {
                Errors[property.Name] = new SmartCollection<ValidationResult>();
            }
        }
    }
    private Dictionary<string, SmartCollection<ValidationResult>> _errors = new Dictionary<string, SmartCollection<ValidationResult>>();
    public Dictionary<string, SmartCollection<ValidationResult>> Errors
    {
        get => _errors;
        set => SetProperty(ref _errors, value);
    }
    protected void Validate(string propertyName, string propertyValue)
    {
        var validationContext = new ValidationContext(this, null)
        {
            MemberName = propertyName
        };
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateProperty(propertyValue, validationContext, validationResults);
        if (!isValid)
        {
            Errors[propertyName].Reset(validationResults);
        }
        else
        {
            Errors[propertyName].Clear();
        }
    }
