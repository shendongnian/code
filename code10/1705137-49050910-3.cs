    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApp7
    {
        public partial class MyUserControl : UserControl
        {
            public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
                "IsChecked", typeof(bool?), typeof(MyUserControl), new PropertyMetadata(default(bool?)));
            public bool? IsChecked
            {
                get { return (bool?) GetValue(IsCheckedProperty); }
                set { SetValue(IsCheckedProperty, value); }
            }
            public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
                "Text", typeof(string), typeof(MyUserControl), new PropertyMetadata(default(string)));
            public string Text
            {
                get { return (string) GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
            public MyUserControl()
            {
                InitializeComponent();
            }
        }
    }
