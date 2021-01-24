    <UserControl
     xmlns:converters="clr-namespace:WhateverYourNamespaceIs.Converters">
    <UserControl.Resources>
    <converters:DebugConverter x:Key="DebugConverter"/>
    </UserControl.Resources>
    
    <Image Name="BackgroundImage" Grid.Row="1" Grid.Column="0" Source="{Binding Path=Background, Converter={StaticResource DebugConverter}" Width="120" Height="90"/>
    
    
    
    
    Here is an example of the converter.
    
    public sealed class DebugConverter : IValueConverter
        { 
         
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                //Debug.WriteLine("Debug Converter Value:" + value.ToString());
                // Since you are working with graphics, maybe just dump the size
    Debug.WriteLine("Debug Converter Value:" + value.Length().ToString());
                return (value);
            }
    
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
