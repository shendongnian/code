    public DetailedViewPage(string position)
    {
        InitializeComponent();
        //Note this line is not "optional" anymore, You must pass the value as a variable.
        this.DataContext = new DetailedViewViewModel(position);
    }
    public class DetailedViewViewModel : BaseViewModel
    {
        public string PossitionShown { get; set; }
        public DetailedViewViewModel(string position)
        {
            PossitionShown = position;
        }
    }
