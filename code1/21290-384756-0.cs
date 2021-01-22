    public class CheckBoxFlagsBehaviour
    {
        private static bool isValueChanging;
        public static Enum GetMask(DependencyObject obj)
        {
            return (Enum)obj.GetValue(MaskProperty);
        } // end GetMask
        public static void SetMask(DependencyObject obj, Enum value)
        {
            obj.SetValue(MaskProperty, value);
        } // end SetMask
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.RegisterAttached("Mask", typeof(Enum),
            typeof(CheckBoxFlagsBehaviour), new UIPropertyMetadata(null));
        public static byte GetValue(DependencyObject obj)
        {
            return (byte)obj.GetValue(ValueProperty);
        } // end GetValue
        public static void SetValue(DependencyObject obj, byte value)
        {
            obj.SetValue(ValueProperty, value);
        } // end SetValue
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(byte),
            typeof(CheckBoxFlagsBehaviour), new UIPropertyMetadata(default(byte), ValueChanged));
        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            isValueChanging = true;
            byte mask = Convert.ToByte(GetMask(d));
            byte value = Convert.ToByte(e.NewValue);
            BindingExpression exp = BindingOperations.GetBindingExpression(d, IsCheckedProperty);
            object dataItem = GetUnderlyingDataItem(exp.DataItem);
            PropertyInfo pi = dataItem.GetType().GetProperty(exp.ParentBinding.Path.Path);
            pi.SetValue(dataItem, (value & mask) != 0, null);
            ((CheckBox)d).IsChecked = (value & mask) != 0;
            isValueChanging = false;
        } // end ValueChanged
        public static bool? GetIsChecked(DependencyObject obj)
        {
            return (bool?)obj.GetValue(IsCheckedProperty);
        } // end GetIsChecked
        public static void SetIsChecked(DependencyObject obj, bool? value)
        {
            obj.SetValue(IsCheckedProperty, value);
        } // end SetIsChecked
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.RegisterAttached("IsChecked", typeof(bool?),
            typeof(CheckBoxFlagsBehaviour), new UIPropertyMetadata(false, IsCheckedChanged));
        private static void IsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (isValueChanging) return;
            bool? isChecked = (bool?)e.NewValue;
            if (isChecked != null)
            {
                BindingExpression exp = BindingOperations.GetBindingExpression(d, ValueProperty);
                object dataItem = GetUnderlyingDataItem(exp.DataItem);
                PropertyInfo pi = dataItem.GetType().GetProperty(exp.ParentBinding.Path.Path);
                byte mask = Convert.ToByte(GetMask(d));
                byte value = Convert.ToByte(pi.GetValue(dataItem, null));
                if (isChecked.Value)
                {
                    if ((value & mask) == 0)
                    {
                        value = (byte)(value + mask);
                    }
                }
                else
                {
                    if ((value & mask) != 0)
                    {
                        value = (byte)(value - mask);
                    }
                }
                pi.SetValue(dataItem, value, null);
            }
        } // end IsCheckedChanged
        private static object GetUnderlyingDataItem(object o)
        {
            return o is DataRowView ? ((DataRowView)o).Row : o;
        } // end GetUnderlyingDataItem
    } // end class CheckBoxFlagsBehaviour
