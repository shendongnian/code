    public void CheckBoxOnClick()
    {
        if (URLModel.IsChecked)
            UrlsList = new ObservableCollection<URLModel>(allUrls.Where(url => url.ExistsInDb));
        else
            UrlsList = new ObservableCollection<URLModel>(allUrls.Where(url => !url.ExistsInDb));
    }
