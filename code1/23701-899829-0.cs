    // best, using Color's static method
    Color red1 = Color.FromName("Red");
    // using a ColorConverter
    TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color)); // ..or..
    TypeConverter tc2 = new ColorConverter();
    Color red2 = (Color)tc.ConvertFromString("Red");
    // using Reflection on Color or Brush
    Color red3 = (Color)typeof(Color).GetProperty("Red").GetValue(null, null);
    // in WPF you can use a BrushConverter
    SolidColorBrush redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
