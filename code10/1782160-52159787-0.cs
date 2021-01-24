    private async void LoadMachineData()
    {
        try
        {
            scope.Connect();
            try
            {
                var tasks = new List<Task>();
                foreach (KeyValuePair<SelectQueryName, SelectQuery> select in SelectQueryes)
                {
                    tasks.Add(Task.Run(() => machine.SetWMIProperties(select.Key, SelectFromWMI(select.Value, scope))));
                }
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                EventNotifier.LogOnScreen(string.Format("{0}, viz: {1}", ErrorList.GetEIbyID(15).definition, ex.Message));
                EventNotifier.Log(ex, ErrorList.GetEIbyID(15));
            }
        }
        catch (Exception ex)
        {
            EventNotifier.LogOnScreen(string.Format("{0}, viz: {1}", ErrorList.GetEIbyID(16).definition, ex.Message));
            EventNotifier.Log(ex, ErrorList.GetEIbyID(17));
        }
    }
