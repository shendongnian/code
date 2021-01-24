    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Parameter != null)
        {
            List<string> ls = e.Parameter as List<string>;
            foreach (var item in ls)
            {
                Debug.WriteLine(item);
            }
        }
    }
