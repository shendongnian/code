        public partial class MagicBox : ContentView
        {
    
        public static readonly BindableProperty TextProperty =
          BindableProperty.Create("Text", typeof(string), typeof(MagicBox), "XX", BindingMode.OneWay, null, new BindableProperty.BindingPropertyChangedDelegate(TextPropertyChanged));
