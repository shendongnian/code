        private void Library_Finished(object sender, EventArgs e)
        {
            Action action = () => FinalUpdate();
            if (Thread.CurrentThread != Dispatcher.Thread)
            {
                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, action);
            }
            else
            {
                action();
            }
        }
