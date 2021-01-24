    List<MyType> _result;
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _result = openDialog();
    }
    private List<MyType> openDialog()
    {
        Window myView = new Window();
        MyViewModel myViewModel = new MyViewModel();
        myView.DataContext = myViewModel;
        myView.ShowDialog();
        List<MyType> result = myViewModel.Result;
        WeakReference viewModelWeakReference = new WeakReference(myViewModel);
        myView.DataContext = null;
        myViewModel = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        bool isViewModelAlive = viewModelWeakReference.IsAlive;
        return result;
    }
