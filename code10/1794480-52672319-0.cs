     public MainViewModel()  //the constructor for the viewmodel
        {
            _Repo = CurrentApp.MainController.RepositoryManager; // this is my database access methods
            Task t = Task.Run(CheckMessagesAsyncInfiniteLoop);  //run the new thread
        }
        private async Task CheckMessagesAsyncInfiniteLoop()  //this is my infinite loop as described in the above link, but run from the above Task.Run
        {
            while (true)
            {
                // Check the messages in the database
                 Messages = _Repo.Service_Message_GetList(CurrentApp.CurrentUser.BasicInfo.UserID);
                
                // pause for the next check
                await Task.Delay(30000);
            }
        }
        Repository.DomainLayer.MessageCollection _Messages;  //the collection that will be updated by the thread above
        public Repository.DomainLayer.MessageCollection Messages  //the property that my view is bound to
        {
            get
            {
                return _Messages;
            }
            set
            {
                _Messages = Messages;
                NotifyPropertyChanged();
            }
        }
