    public MainViewModel()
        {
            //Initialize the column to gridlength 0
            MainGridModel MainGridModel = new MainGridModel
            {
                NotamWidth = new GridLength(0)
            };
         }
    //Action on button command
    public void ShowNotamExecute(object parameter)
        {
           //set the column Width
            MainGridModel MainGridModel = new MainGridModel
            {
                NotamWidth = new GridLength(400)
            };
        }
