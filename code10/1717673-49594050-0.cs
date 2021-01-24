        <Window.Resources>
        <ViewModel:BoolToVisibilityConverter x:Key="BoolToVisibilityConverter" />
    <Button Name="btnExportInstaller" Visibility="{Binding SelectedInstaller.IsDownloaded , Converter={StaticResource BoolToVisibilityConverter}}" Margin="5,5,5,5" Height="50" Width="90" MouseDoubleClick="btnExportInstaller_MouseDoubleClick">Export Installer</Button>
        public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            var booool = (bool)value;
            if (booool == false)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is Visibility && (Visibility)value == Visibility.Visible)
            {
                return true;
            }
            return false;
        }
    }
