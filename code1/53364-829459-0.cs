    private void Process_Message(object sender, StringEventArgs e)
    {
         Action action = () => UpdateStatus(e.Message);
         {
             Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, action);
         }
         else
         {
                action();
         }         
    }
