    public static Control Dispather;
    public static void GetTarget(string UserDirectory)// passing the action as an Argument
    {
       ...
       Dispather.Invoke((Action)(() => { List.Items.Add(DateTime.Now + "Hi Log List, GetDir here"); }));
    }
