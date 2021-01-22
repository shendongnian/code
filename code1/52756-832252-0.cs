    static class Validator
    {
        public static readonly DependencyProperty SkipValidationProperty =
            DependencyProperty.RegisterAttached("SkipValidation", typeof(bool), typeof(Validator),
            new UIPropertyMetadata(false));
        public static bool GetSkipValidation(DependencyObject obj)
        {
            return (bool)obj.GetValue(SkipValidationProperty);
        }
        public static void SetSkipValidation(DependencyObject obj, bool value)
        {
            obj.SetValue(SkipValidationProperty, value);
        }
        public static bool IsValid(DependencyObject parent)
        {
            if (Validator.GetSkipValidation(parent)) return true;
           //Rest of the validation code
        }
    }
