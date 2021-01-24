     public class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
                valueAisValid = true;
                valueBisValid = true;
                if (IsInDesignMode)
                {
                    Calc();
                }
            }
    
            #region Properties
    
            private string valueA;
            public string ValueA
            {
                get => valueA;
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        Set(ref valueA, value);
                        Set(ref valueAisValid, double.TryParse(ValueA, out double d));
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
                get => valueB;
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        Set(ref valueB, value);
                        Set(ref valueBisValid, double.TryParse(ValueB, out double d));
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
                get => valueC;
                set => Set(ref valueC, value);
            }
    
            private string valueD;
            public string ValueD
            {
                get => valueD;
                set => Set(ref valueD, value);
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
    
            #endregion
        }
