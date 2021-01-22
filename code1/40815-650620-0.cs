     public class ImageButton
        {
        
            public static ImageSource GetImage(DependencyObject obj)
            {
                return (ImageSource)obj.GetValue(ImageProperty);
            }
        
            public static void SetImage(DependencyObject obj, ImageSource value)
            {
                obj.SetValue(ImageProperty, value);
            }
        
            public static readonly DependencyProperty ImageProperty =
                DependencyProperty.RegisterAttached("Image", typeof(ImageSource), typeof(ImageButton), new UIPropertyMetadata(null));
        
            public static String GetCaption(DependencyObject obj)
            {
                return (String)obj.GetValue(CaptionProperty);
            }
        
            public static void SetCaption(DependencyObject obj, String value)
            {
                obj.SetValue(CaptionProperty, value);
            }
        
            public static readonly DependencyProperty CaptionProperty =
                DependencyProperty.RegisterAttached("Caption", typeof(String), typeof(ImageButton), new UIPropertyMetadata(null));
            
        }
    <Style TargetType="{x:Type Button}"
                   x:Key="ImageButton">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Image Source="{Binding Path=(local:ImageButton.Image), RelativeSource={RelativeSource AncestorType={x:Type Button}}}" />
                                <TextBlock Text="{Binding Path=(local:ImageButton.Caption), RelativeSource={RelativeSource AncestorType={x:Type Button}}}"
                                           Margin="2,0,0,0" />
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>   
            </Style>
