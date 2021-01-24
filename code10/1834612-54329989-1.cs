            public bool SelectMainEventViaErrorEvent(int eventIdx)
        {
            bool bSuccess = false;
            DisableToolTips(true);
            errorEvents.Select(eventIdx);
            errorEvents.SelectedItem.DoubleClick();
            System.Threading.Thread.Sleep(1000);
            log.Info($"SelectMainEventViaErrorEvent({eventIdx}) selected error event = {errorEvents.SelectedItemText}");
            log.Info($"SelectMainEventViaErrorEvent({eventIdx}) selected main event = {mainEvents.SelectedItemText}");
            if (errorEvents.SelectedItemText == mainEvents.SelectedItemText)
            {
                bSuccess = true;
            }
            return bSuccess;
        }
