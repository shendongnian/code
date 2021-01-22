     protected void ScriptManager_Navigate(object sender, HistoryEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.State["myArgs"]))
            {
                string args = e.State["myArgs"];
                SetMyArgs(args);                           
            }
            else
            {
                // just load default
            }
        }
