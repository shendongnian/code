    [assembly: ExportRenderer(typeof(Picker), typeof(CustomPicker))]
    namespace Droid
    {
        public class CustomPicker : PickerRenderer
        {
    
            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged (e);
                if (Control != null) 
                    Control.SetHintTextColor (Android.Graphics.Color.Rgb(1,2,3));
                
            }
    
        }
    
    }
