    public class PageViewModel : ... //some interface or else 
    {
        public DelegateCommand PageLoaded;
        public PageViewModel(...)
        {
             PageLoaded = new DelegateCommand(async () =>
             {
                    IsBusy = true;      
                    CreateServices();  
                    await PopulateBinders();
                    await Task.WhenAll(new[]
                    {
                        PopulateBoardFiles(),
                        PopulateBoardEvents()
                    });               
                    IsBusy = false;
             });
        }
    }
