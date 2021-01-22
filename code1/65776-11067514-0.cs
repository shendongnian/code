    void SetAllCommandTimeouts(object adapter, int timeout)
    {
        var commands = adapter.GetType().InvokeMember(
                "CommandCollection",
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, adapter, new object[0]);
        var sqlCommand = (SqlCommand[])commands;
        foreach (var cmd in sqlCommand)
        {
            cmd.CommandTimeout = timeout;
        }
    }
    // unfortunately this still requires work after a TableAdapter is obtained...
    var ta = new MyTableAdapter();
    SetAllCommandTimeouts(ta, 120);
    var t = ta.GetData();
