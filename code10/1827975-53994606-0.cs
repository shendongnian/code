    List<CustomModel> listOfCustomModels = await GetListOfCustomModelsAsync();
    foreach (var customModel in listOfCustomModels)
    {
        MyCustomControl customControl = new MyCustomControl
        {
            Source = customModel.Image,
            Text = customModel.Text
        };
        wrapLayout.Children.Add(customControl);
    }
