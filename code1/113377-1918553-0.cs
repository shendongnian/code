    private void ChildThreadUpdater()
    {
      yourControl.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background
        , new System.Threading.ThreadStart(delegate
          {
            // update your control here
          }
        ));
    }
