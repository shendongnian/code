    public static class Commands
    {
        public static readonly RoutedCommand testcommand = new RoutedCommand();
    }
    private void MyCmd_Executed(object sender, ExecutedRoutedEventArgs e)
     {
         string parameter = (string)e.Parameter;
         MessageBox.Show(parameter);
     }
