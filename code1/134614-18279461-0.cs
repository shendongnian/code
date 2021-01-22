        public void SearchForFooAsync(string searchString)
        {
            var caller = new Func<string, Foo>(_patientProxy.SearchForFoo);
            caller.BeginInvoke(searchString, new AsyncCallback(SearchForFooCallbackMethod), null);
        }
        
        public void SearchForFooCallbackMethod(IAsyncResult ar)
        {
        
                var foo = GetFooFromAsyncResult(ar); 
    InkPresenter inkPresenter;
                new XTATestRunner().RunSTA(() => {
                            inkPresenter = XamlReader.Parse(foo.Xaml) as InkPresenter;
                        });
        }
   
