    var sharedContext = new MyViewModel();
    var viewOne = new MyWindow();
    var viewTwo = new MyUserControl();
    viewOne.DataContext = viewTwo.DataContext =  sharedContext;
   
