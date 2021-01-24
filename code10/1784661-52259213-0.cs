       <local:CustomButton  Command="{Binding Model.ZoomOnImage}" MousePosition="{Binding MousePosition}">
                <Image Source="{Binding Model.ImageSource}" Stretch="Uniform" />
            </local:CustomButton>
    
     public class CustomButton : Button
            {
        
                public Point MousePosition
                {
                    get { return (Point)GetValue(MousePositionProperty); }
                    set { SetValue(MousePositionProperty, value); }
                }
                // Using a DependencyProperty as the backing store for MousePosition.  This enables animation, styling, binding, etc...
                public static readonly DependencyProperty MousePositionProperty = DependencyProperty.Register("MousePosition", typeof(Point), typeof(CustomButton), new FrameworkPropertyMetadata(new Point(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        
                protected override void OnClick()
                {
                    base.OnClick();
                    MousePosition = Mouse.GetPosition(this);
                }
            }
