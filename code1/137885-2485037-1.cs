    private void bwUpdateParameters_DoWork(object sender, DoWorkEventArgs e)
    {
        var updates = (IEnumerable<ParameterUpdate>)e.Argument;
        foreach (var update in updates)
        {
            WriteDeviceParameter(update.Name, update.Value);
            update.Value = ReadDeviceParameter(update.Name);
        }
        e.Result = updates;
    }
    private void bwUpdateParameters_RunWorkerCompleted(object sender,
        RunWorkerCompletedEventArgs e)
    {
        var updates = (IEnumerable<ParameterUpdate>)e.Argument;
        foreach (var update in updates)
        {
            if (update.Callback != null)
            {
                update.Callback(update.Value);
            }
        }
    }
