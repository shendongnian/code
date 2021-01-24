    public class MValConv : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values.Length == 2 && values[0] is ObservableCollection<Student> ocol && values[1] is Student st)
                {
                    return (ocol.IndexOf(st) + 1).ToString();
                }
            }
            catch (Exception)
            {
            }            
            return Binding.DoNothing;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("one way only");
        }
    }
    <Window.Resources>
        <local:MValConv x:Key="MValCnv"/>
    </Window.Resources>
    <dxg:GridColumn.Binding>
        <MultiBinding Converter="{StaticResource MValCnv}">
            <Binding Path="DataContext.StudentsCollection" RelativeSource="{RelativeSource AncestorType=dxg:GridControl}"/>
            <Binding/>
        </MultiBinding>
    </dxg:GridColumn.Binding>  
  
