    <Style TargetType="Grid">
        <Setter Property="Background" Value="Red" />
        <EventSetter Event="PreviewMouseDown" Handler="Grid_PreviewMouseDown"/>
        <!--Uncomment the line below to see that button seems to be hidden under the grid.-->
        <!--<Setter Property="Opacity" Value="0.5" />-->
    </Style>
,
    public partial class App : Application
    {
        private void Grid_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show(VisualTreeHelper.GetParent(sender as Grid).ToString());
        }
    }
  
