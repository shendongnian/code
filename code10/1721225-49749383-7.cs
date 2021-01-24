    public class BindingSourcePropertyConverter: IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            DataTransferEventArgs e = (DataTransferEventArgs)value;
            BindingExpression binding = ((FrameworkElement)e.TargetObject).GetBindingExpression(e.Property);
            return binding.ResolvedSourcePropertyName ?? "";
        }
    }
