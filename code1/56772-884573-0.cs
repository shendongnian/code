    void RunAsync<T>(Action<T> action)
    {
        AsyncCallback Done = action.EndInvoke;
        SPSecurity.RunWithElevatedPrivileges(() => action.BeginInvoke(properties, Done, null));
    }
    RunAsync(DeleteWorkspace);
