    public class MyButton : Button {
    
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            "CornerRadius", typeof(CornerRadius), typeof(MyButton), new PropertyMetadata(default(CornerRadius)));
    
        public CornerRadius CornerRadius {
            get { return (CornerRadius) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
