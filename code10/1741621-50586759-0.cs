    private void Test(object sender, RoutedEventArgs e)
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
        bool isViewModelAlive = viewModelWeakReference.IsAlive; //=false
    }
    ...
    public class MyViewModel
    {
        public List<MyType> Result { get; } = new List<MyType>() { new MyType(), new MyType() };
    }
