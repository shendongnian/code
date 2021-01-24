    private EventViewModel _SelectedEvent;
    public EventViewModel SelectedEvent
    {
        get { return _SelectedEvent; }
        set { _SelectedEvent = value; OnPropertyChanged("SelectedEvent"); }
    }
2. You need to change the binding path of the SelectedItem in the ComboBox. Bind it to the new Property SelectedEvent. Now, every time you select an item in the combo box, the SelectedEvent property will change. 
<ComboBox.SelectedItem>
    <Binding Path="SelectedEvent" UpdateSourceTrigger="PropertyChanged">
        <Binding.ValidationRules>
        <local:EventNameValidationRule ValidatesOnTargetUpdated="True"/>
        </Binding.ValidationRules>
    </Binding>
</ComboBox.SelectedItem>
3. Since the binding was changed, the validation rule will now expect an EventViewModel in the value parameter. Therefore you need to adjust the ValidateMethod a little bit. 
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value == null)
            return new ValidationResult(false, "Please select a Event");
        if (value is EventViewModel eventVm)
        {
        string eventName = eventVm.EventName == null ? "" : value.ToString();
        return string.IsNullOrEmpty(eventName)
            ? new ValidationResult(false, "Please select a Event")
            : ValidationResult.ValidResult;
        }
        throw new Exception("Invalid binding!"); 
    }
