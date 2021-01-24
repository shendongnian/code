    public class MainViewModel : IMainViewModel
    {
        DelegateCommand DoStuffCommand { get; }
        ICommand IMainViewModel.DoStuffCommand => DoStuffCommand;
    }
