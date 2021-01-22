    public void UpdateUI(object arg)
    {
        controlToUpdate.Dispatcher.BeginInvoke(
            System.Windows.Threading.DispatcherPriority.Normal
            , new System.Windows.Threading.DispatcherOperationCallback(delegate
            {
                controToUpdate.property = arg;
                return null;
            }), null);
        }
    } 
