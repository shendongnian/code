<Application.Resources>
    <Style TargetType="ComboBox">
        <EventSetter Event="PreviewMouseWheel" Handler="ComboBox_PreviewMouseWheel" />
    </Style>
</Application.Resources>
**App.xaml.cs**
private void ComboBox_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
{
    e.Handled = !((System.Windows.Controls.ComboBox)sender).IsDropDownOpen;
}
