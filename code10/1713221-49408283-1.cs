    public class CombinedViewModel : ViewModelBase
    {
        public FirstViewModel FirstViewModel { get;set;}
        public SecondViewModel SecondViewModel { get; set; }
    
        public CombinedViewModel()
        {
            this.FirstViewModel = new FirstViewModel();
            this.SecondViewModel = new SecondViewModel();
        }
    }
