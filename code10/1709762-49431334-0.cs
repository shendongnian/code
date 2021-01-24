        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
          BackgroundWorker worker = sender as BackgroundWorker;
            ScriptModel _newFileResult = new ScriptModel();
            ObservableCollection<ScriptModel> _scriptCollectionTemp = new ObservableCollection<ScriptModel>();
            for (int i = 0; i < ScriptCollection.Count; i++ )
            {
                _newFileResult = CheckOutResults.CheckOutResultFiles(ScriptCollection[i], BatteryLocation, SelectedMachine.Machine);
                _scriptCollectionTemp.Add(_newFileResult);
                worker.ReportProgress(_scriptCollectionTemp.Count);
            }
            ScriptCollection = _scriptCollectionTemp;
        }
