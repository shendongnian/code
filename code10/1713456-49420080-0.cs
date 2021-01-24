    mainlist.ItemsSource = new ObservableCollection<Mainlist>();
    foreach (var item in yourDataFromHtmlAgilityPackScraping) {
        mainlist.ItemsSource.Add(new Mainlist()
                {
                    //scraped info from each URL
                    Title = item.title.ToString().Trim(),
                    Value = item.value.ToString().Trim(),
                });
    }
