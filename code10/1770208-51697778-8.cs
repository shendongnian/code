    public static void GetTarget(string UserDirectory, ListBox List)// passing ListBox as an Argument
    {
       ...
       Invoke((Action)(() => { List.Items.Add(DateTime.Now + "Hi Log List, GetDir here"); })); // THIS DOESN'T WORK
    }
