    var watcher = new DependencyPropertyWatcher<string>(this.MyWebView, "Source");
    watcher.PropertyChanged += Watcher_PropertyChanged;
    
    private void Watcher_PropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
       
    }
