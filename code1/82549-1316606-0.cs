    <StackPanel Margin="{Binding TopMargin, Converter={StaticResource MyThicknessConverter}">
.
    public class ThicknessSingleValueConverter : IValueConverter
    {
        override Convert(...)
        {
             return new Thickness(0, (double)object, 0, 0);
        }
      
        //etc...
