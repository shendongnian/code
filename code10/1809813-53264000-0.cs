    using System.Windows;
    using System.Windows.Interactivity;
    
    namespace testtestz
    {
        public class ClosingBehavior : Behavior<Window>
        {
            protected override void OnAttached()
            {
                AssociatedObject.Closing += AssociatedObject_Closing;
            }
    
            protected override void OnDetaching()
            {
                AssociatedObject.Closing -= AssociatedObject_Closing;
            }
    
            private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                e.Cancel = MessageBox.Show("Close the window?", AssociatedObject.Title, MessageBoxButton.OKCancel) == MessageBoxResult.Cancel;
            }
        }
    }
