    public class GameSettings : Page
    {
        private INavigator _navigator;
        public GameSettings(INavigator navigator)
        {
            _navigator = navigator;
        }
    
        private void SetSomeValuesAndNavigateToGamePage()
        {
            //...
            _navigator.Navigate(new GamePage(_navigator));
        }
    }
    public class GamePage : Page
    {
        private int numberOfPlayers;
        private Player[] players;
        private INavigator _navigator;
        public GamePage(INavigator navigator)
        {
            _navigator = navigator;
             // initialize game properties, check if they are set.
            var gameProp = new GameProperties();
            this.numberOfPlayers = 2;
            this.players = gameProp.CheckPlayerIsSet(this.players);
            //check if a player has been set
            if (this.players != null)
            { // Player is set or has been set. proceed or start the game.
                InitializeComponent();
            }
            else
            {   // redirect to settings window because players has not been set!
                _navigator.Navigate(new GameSettings(_navigator));
            }
        }
    }
    public class MainWindow : INavigator
    {
        private void DoStuffAndNavigateToGameWindow()
        {
            //...
            Navigate(new GameSettings(this));
        }
        public void Navigate(Page p)
        {
            _mainFrame.Navigate(p);
        }
    }
    public interface INavigator
    {
        void Navigate(Page p);
    }
