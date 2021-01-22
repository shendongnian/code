    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication3
    {
        public class RoundedButton:Button
        {
            public CornerRadius CornerRadius
            {
                get { return (CornerRadius) GetValue(CornerRadiusProperty); }
                set { SetValue(CornerRadiusProperty, value); }
            }
            public static readonly DependencyProperty CornerRadiusProperty =
                DependencyProperty.Register("CornerRadius", typeof (CornerRadius), 
                typeof (RoundedButton), new UIPropertyMetadata());
        }
    }
