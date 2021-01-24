    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                
                if (value is MyObjectViewModel objectViewModel && parameter is AnotherObjectRowViewModel anotherObjectRowViewModel)
                {
                    return anotherObjectRowViewModel.MyObjects.Contains(objectViewModel);
                }
                return false;
            }
