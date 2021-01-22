    private var foo;
    public void SearchForFooCallbackMethod(IAsyncResult ar)
    {
        foo = GetFooFromAsyncResult(ar); 
        Thread thread = new Thread(ProcessInkPresenter);
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join(); 
    }
    private void ProcessInkPresenter()
    {
        var inkPresenter = XamlReader.Parse(foo.Xaml) as InkPresenter;
    }
