    public class MainWindowViewModel : BaseViewModel {
        private readonly ApplicationDbContext db;
     
        public MainWindowViewModel(ApplicationDbContext db) {
            this.db = db;            
        }
     
        private ICommand goPack;
        public ICommand GoPack {
            get {
                return goPack
                    ?? (goPack = new ActionCommand(() =>
                    {
                        var c = db.Parts;
                        FrameContent.Navigate(new PageConsignments());
                    }));
            }
        }
    }
    
