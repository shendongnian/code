    private void ViewModel_PerformPrimeAction(InstrumentAction Action)
    {
        bool abort = false;
        CommandRunningWindow cmdDialog = null;
        if (Action == InstrumentAction.Prime)
        {
            if (Xceed.Wpf.Toolkit.MessageBox.Show((string)TryFindResource("ConfirmPrimeInstrument"),
                ApplicationSettingsViewModel.Instance.ProductName, MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;
            this.IsEnabled = false;
            //This below line never shows the message.
            cmdDialog = ShowCommandWindow(ViewModelsHelper.GetResourceString("PerformingPrime"));
        }
        UIUtils.OverrideCursor = System.Windows.Input.Cursors.Wait;
        Task.Factory.StartNew(() =>
        {
            // This operation takes 10 seconds
            QXInstrumentViewModel.Instance.Prime(() => { if (abort) throw new RunAbortedException(null); });
        })
        .ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                if (task.Exception != null && task.Exception.GetBaseException() is RunAbortedException)
                {
                    var message = QXInstrumentViewModel.ToErrorCode(ex);
                    TokenSource = new System.Threading.CancellationToken(true);
                    if (message != null)
                    {
                        errorMessage = string.Format((string)TryFindResource("CompletePrimeInstrumentWithError"), Convert.ToInt32(message), errorMessage);
                    }
                    else
                    {
                        errorMessage = (string)TryFindResource("CompletePrimeInstrumentWithUnknownError");
                    }
                }
                else
                {
                    errorMessage = (string)TryFindResource("CompletePrimeInstrumentAborted");
                }
            }
            cmdDialog?.Close();
            UIUtils.OverrideCursor = null;
            this.IsEnabled = true;
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
