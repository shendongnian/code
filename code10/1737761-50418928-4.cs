    public class WelcomeViewModel : BaseViewModel
    {
        public ICommand NewGameCmd { get; }
        public ICommand TopScoreCmd { get; }
        public ICommand AboutCmd { get; }
    
        public WelcomeViewModel(INavigationService navigation) : base(navigation)
        {
            NewGameCmd = new Command(async () => await Navigation.PushModalAsync<GameViewModel>());
            TopScoreCmd = new Command(async () => await navigation.PushModalAsync<TopScoreViewModel>());
            AboutCmd = new Command(async () => await navigation.PushModalAsync<AboutViewModel>());
        }
    }
