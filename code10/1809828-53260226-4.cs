    public void CheckBoxOnClick()
    {
        if (URLModel.IsChecked)
            UrlsList = new ObservableCollection<URLModel>(UrlsList.Where(url => url.ExistsInDb));
        else
            UrlsList = new ObservableCollection<URLModel>(UrlsList.Where(url => !url.ExistsInDb));
    }
