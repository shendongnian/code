    public class MultiLabel : Label
    {
        public static readonly BindableProperty Value1Property = BindableProperty.Create(nameof(Value1), typeof(string), typeof(MultiLabel), string.Empty, propertyChanged: OnValueChanged);
        public static readonly BindableProperty Value2Property = BindableProperty.Create(nameof(Value2), typeof(string), typeof(MultiLabel), string.Empty, propertyChanged: OnValueChanged);
        public static readonly BindableProperty Value3Property = BindableProperty.Create(nameof(Value3), typeof(string), typeof(MultiLabel), string.Empty, propertyChanged: OnValueChanged);
        public static readonly BindableProperty Value4Property = BindableProperty.Create(nameof(Value4), typeof(string), typeof(MultiLabel), string.Empty, propertyChanged: OnValueChanged);
        public static readonly BindableProperty Value5Property = BindableProperty.Create(nameof(Value5), typeof(string), typeof(MultiLabel), string.Empty, propertyChanged: OnValueChanged);
    
        public string Value1
        {
            get { return (string)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }
    
        public string Value2
        {
            get { return (string)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }
    
        public string Value3
        {
            get { return (string)GetValue(Value3Property); }
            set { SetValue(Value3Property, value); }
        }
    
        public string Value4
        {
            get { return (string)GetValue(Value4Property); }
            set { SetValue(Value4Property, value); }
        }
    
        public string Value5
        {
            get { return (string)GetValue(Value5Property); }
            set { SetValue(Value5Property, value); }
        }
    
        static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var label = (MultiLabel)bindable;
    
            label.Text = label.Value1 + label.Value2 + label.Value3 + label.Value4 + label.Value5;
        }
    }
