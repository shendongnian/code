    private static void TextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myControl = (UCInputField)d; //This is the reference that is needed
            myControl.InternalValue = Convert.ToDouble(e.NewValue) * factor; //You can user factor since it is static
        }
