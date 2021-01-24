        public partial class MagicBox : ContentView
        {
    
        public static readonly BindableProperty TextProperty =
          BindableProperty.Create("Text", typeof(TextVM), typeof(MagicBox), "XX", BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(TextPropertyChanged));
        
        public TextVM Text
        {
            get { return (TextVM)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
            
