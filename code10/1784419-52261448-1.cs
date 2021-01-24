    public class MainViewModel : ViewModelBase
        {
            public ICommand MouseEnterCommand { get; set; }
            public ICommand MouseLeaveCommand { get; set; }
            public MainViewModel()
            {
                valueAisValid = true;
                valueBisValid = true;
                MouseEnterCommand = new RelayCommand<object>(MouseEnterCommandHandler);
                MouseLeaveCommand =new  RelayCommand<object>(MouseLeaveCommandHandler);
                if (IsInDesignMode)
                {
                    Calc();
                }
            }
    
            #region Properties
    
            private string _backgroundColor;
            public string BackgroundColor
            {
                get { return _backgroundColor; }
                set { _backgroundColor = value; NotifyPropertyChanged(nameof(BackgroundColor)); }
            }
    
    
            private string valueA;
            public string ValueA
            {
                get { return valueA; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        double d;
                        Set(ref valueA, value);
                        Set(ref valueAisValid, double.TryParse(ValueA, out d));
                        NotifyPropertyChanged(nameof(ValueAIsValid));
                        Calc();
                    }
                }
            }
    
            private bool valueAisValid;
            public bool ValueAIsValid => valueAisValid;
    
            private string valueB;
            public string ValueB
            {
                get { return valueB; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        double d;
                        Set(ref valueB, value);
                        Set(ref valueBisValid, double.TryParse(ValueB, out d));
                        NotifyPropertyChanged(nameof(ValueBIsValid));
                        Calc();
                    }
                }
            }
    
            private bool valueBisValid;
            public bool ValueBIsValid => valueBisValid;
    
            private string valueC;
            public string ValueC
            {
                get { return valueC; }
                set { Set(ref valueC, value); }
            }
    
            private string valueD;
            public string ValueD
            {
                get { return valueD; }
                set { Set(ref valueD, value); }
            }
    
            public bool InputsValid => ValueAIsValid && ValueBIsValid;
    
            #endregion
    
            #region Methods
    
            private void Calc()
            {
                if (InputsValid)
                {
                    double sum = Convert.ToDouble(valueA) + Convert.ToDouble(valueB);
                    double product = Convert.ToDouble(valueA) * Convert.ToDouble(valueB);
                    ValueC = sum.ToString(CultureInfo.InvariantCulture);
                    ValueD = product.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    ValueC = "NAN";
                    ValueD = "NAN";
                }
            }
    
            private void MouseEnterCommandHandler(object parameter)
            {
                if (parameter != null)
                {
                    BackgroundColor = parameter.ToString();
                }
            }
    
            private void MouseLeaveCommandHandler(object parameter)
            {
                if (parameter !=null)
                {
                    BackgroundColor = parameter.ToString();
                }
            }
    
            #endregion
        }
