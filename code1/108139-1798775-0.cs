    public class MainControlViewModel : ObservableObject
    {
        public FirstControlViewModel firstControlViewModel;
        public SecondControlViewModel firstControlViewModel;
        public ICommand FilterCommand;
        public FilterSettings FilterSettings;
        public MainControlViewModel()
        {
            //...
            this.firstControlViewModel = new FirstControlViewModel(this.FilterSettings, this.FilterCommand);
            this.secondControlViewModel = new SecondControlViewModel(this.FilterSettings, this.FilterCommand);
        }
    }
    public class FirstControlViewModel : ObservableObject
    {
        //...
    }
    public class SecondControlViewModel : ObservableObject
    {
        //...
    }
