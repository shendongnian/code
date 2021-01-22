     public class ThirdPartyButtonProperty
     {
       public static object GetContent(...
       public static void SetContent(...
       public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached("Content", typeof(object), typeof(ThirdPartyButtonProperty), new PropertyMetadata
       {
         PropertyChangedCallback = (obj, e) =>
         {
           ((CustomButton)obj).InternalControl.Content = (object)e.NewValue;
         }
       });
     }
