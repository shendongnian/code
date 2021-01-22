    public MyDependencyObject(){
      Loaded += OnLoaded;
    }
    
    private void OnLoaded(object sender, EventArgs args){
      DoThings();
      Loaded -= OnLoaded;
    }
