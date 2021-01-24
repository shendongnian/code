    //Here you have the grid
    Grid element = (Grid)XamlReader.Parse(xaml, context);
    //Now try to get the button
    Button btn = (Button)element.FindName("BtnEditAc");
    if(btn != null)
    {
        btn.Click  += new RoutedEventHandler(OnBtnEditAcClick);
    }
