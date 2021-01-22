    [TypeConverter(typeof(FormStateConverter))]
    public class FormState : INotifyPropertyChanged, IDisposable {
       private Size _Size = Size.Empty;
       private Point _Location = Point.Empty;
       private FormWindowState _WindowState = FormWindowState.Normal;
    
       public FormState(Form form) { BindTo(form); }
    
       internal FormState(Size size, Point location, FormWindowState state) {
          _Size = size;
          _Location = location;
          _WindowState = state;
       }
    
       // lotsa other code...
    }
    
    internal class FormStateConverter : ExpandableObjectConverter {
       public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
          if (destinationType == typeof(string)) {
             return true;
          } else {
             return base.CanConvertFrom(context, destinationType);
          }
       }
    
       public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
          if (sourceType == typeof(string)) {
             return true;
          } else {
             return base.CanConvertFrom(context, sourceType);
          }
       }
    
       // This converts a FormState to a string, we're just making a CSV string here...
       public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
          if (destinationType == typeof(String)) {
             FormState formState = (FormState)value;
             string converted = string.Format("{0},{1},{2},{3},{4}", formState.Size.Height, formState.Size.Width,
                formState.Location.X, formState.Location.Y, formState.WindowState.ToString());
             return converted;
          }
    
          return base.ConvertTo(context, culture, value, destinationType);
       }
    
       // This converts a string back into a FormState instance.
       public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
          if (value is string) {
             string formStateString = (string)value;
             string[] parts = formStateString.Split(','); // split the CSV string
    
             if (parts != null && parts.Length == 5) { // attempt some error checking
                Size size = new Size();
                Point location = new Point();
                FormWindowState state = FormWindowState.Normal;
    
                int tmp;
                size.Height = (Int32.TryParse(parts[0], out tmp)) ? tmp : 0;
                size.Width = (Int32.TryParse(parts[1], out tmp)) ? tmp : 0;
                location.X = (Int32.TryParse(parts[2], out tmp)) ? tmp : 0;
                location.Y = (Int32.TryParse(parts[3], out tmp)) ? tmp : 0;
    
                if (string.Equals(parts[4], "maximized", StringComparison.OrdinalIgnoreCase)) {
                   state = FormWindowState.Maximized;
                } else if (string.Equals(parts[4], "minimized", StringComparison.OrdinalIgnoreCase)) {
                   state = FormWindowState.Minimized;
                } else {
                   state = FormWindowState.Normal;
                }
    
                return new FormState(size, location, state);
             }
          }
    
          return base.ConvertFrom(context, culture, value);
       }
    }
