        private void UpdateTextBlock(TextBlock textBlockArg, string textArg)
        {
            textBlockArg.Dispatcher.Invoke(
               System.Windows.Threading.DispatcherPriority.Normal
               , new System.Windows.Threading.DispatcherOperationCallback(delegate
               {
                   textBlockArg.Text = textArg;
                   return null;
               }), null);
        }
