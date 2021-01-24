    public class MyDataGridCellCommand : RoutedUICommand
    {
        public MyDataGridCellCommand()
        {
            this.InputGestures.Add(new KeyGesture(Key.F1));
            this.Text = "Process selected cell";
            
        }
        public void OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (FocusManager.GetFocusedElement(sender as DependencyObject) is DataGridCell) {
                //Process selected cell...
            }
        }
        public void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (FocusManager.GetFocusedElement(sender as DependencyObject) is DataGridCell);
        }
    }
