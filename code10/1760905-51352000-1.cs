    //you need access to listview object
    //set the number of columns based on the current width of listview
    if(listview.ActualWidth <= 350)
        NumberOfColumns = 3;
    else if(...)
        ...
    //ImageUserList.Count = number of all items
    //listview.ItemsSource.Cast<object>().Count() can be used instead
    NumberOfRows = (int)Math.Ceiling(ImageUserList.Count / (double)NumberOfColumns);
