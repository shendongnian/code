     private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync();
                TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            }
            if (tabControl1.TabPages.Count > 10 && tabControl1.SelectedTab != null)
                UpdatePreviewBitmap(tabControl1.SelectedTab);
