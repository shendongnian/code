    if ((areaListViewIsVisible && areaList.Any(folder => folder.Title.ToLower() == pResult.Text.ToLower())||
        (productListViewVisible && productListareaList.Any(folder => folder.Title.ToLower() == pResult.Text.ToLower()))
    {
        await Application.Current.MainPage.DisplayAlert("Error", "You cannot add a folder with the same name.", "OK");
        return;
    }
