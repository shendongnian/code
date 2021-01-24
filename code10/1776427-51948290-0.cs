    public ObservableCollection<string> ProjectList { get; internal set; } = new ObservableCollection<string>();
    public static async Task PopiuateProjectListAsync()
    {
        ProjectList.Clear();
        MyObject resultparsed = await Task.Run(() =>
        {
            string result = TestMethodAsync("getProjects", GetApiKeyAsync());
            return new JavaScriptSerializer().Deserialize<MyObject>(result);
        });
        foreach (SomeItem item in resultparsed.result.items)
        {
            ProjectList.Add(item.SomeStringProperty);
        }
    }
