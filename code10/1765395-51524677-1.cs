     Public Class MainViewModel
    {
       Command clickCommand;
        public Command ClickCommand
        {
            get
            {
           return clickCommand ?? (menuTapCommand = new Command<Object>(GetImage));
            }
        }
    Private Void GetImage(Object obj)
    {
     //Todo
    }}
