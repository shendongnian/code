      <TabControl>
        <TabItem Header="Test">
            <TabItem.Foreground>
                <MultiBinding Converter="{StaticResource MultiEval}">
                    <Binding  ElementName="CB1" Path="IsChecked"/>
                    <Binding  ElementName="CB2" Path="IsChecked"/>
                    <Binding  ElementName="CB3" Path="IsChecked"/>
                </MultiBinding>            
            </TabItem.Foreground>
            <StackPanel>                
                <CheckBox Name="CB1"></CheckBox>
                <CheckBox Name="CB2"></CheckBox>
                <CheckBox Name="CB3"></CheckBox>
            
            </StackPanel>
        </TabItem>
    <Window.Resources>
        <loc:MultiEvaluator x:Key="MultiEval"/>
    </Window.Resources>
    public class MultiEvaluator : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (!System.Convert.ToBoolean(value))
                {
                    return Brushes.Red;
                }
            }
            return Brushes.Black;
        } 
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
