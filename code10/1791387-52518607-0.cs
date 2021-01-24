    using CommonServiceLocator;
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;   
    
    namespace Converters
    {
       class HasErrorToBindingDoNothingConverter : DependencyObject, IValueConverter
       {
          public static readonly DependencyProperty ViewModelTypeProperty =
            DependencyProperty.Register("ViewModelType", typeof(string), typeof(HasErrorToBindingDoNothingConverter), new UIPropertyMetadata(""));
    
        public string ViewModelType
        {
            get { return (string)GetValue(ViewModelTypeProperty); }
            set { SetValue(ViewModelTypeProperty, value); }
        }
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                ViewModel.ViewModelBaseWithNavigation vm;
                System.Reflection.Assembly asm = typeof(ViewModelLocator).Assembly;
                Type type = null;
    
                if (type == null)
                    type = asm.GetType(ViewModelType);
    
                if (type == null)
                    type = asm.GetType("TeachpendantControl.ViewModel." + ViewModelType);
    
                vm = (ViewModel.ViewModelBaseWithNavigation)ServiceLocator.Current.GetInstance(type);
    
                if (vm.HasErrors)
                    return Binding.DoNothing;
                else
                    return value;
            }
            catch { return value; }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    }
