    public class GameWindow
    {
        private INavigator _navigator;
        public GameWindow(INavigator navigator)
        {
            _navigator = navigator;
        }
    
        private void SetSomeValuesAndNavigateToAnotherPage()
        {
            //...
            _navigator.Navigate(new GameWindow(_navigator));
        }
    }
    public class MainWindow : INavigator
    {
    
        private void DoStuffAndNavigateToGameWindow()
        {
            Navigate(new GameWindow(this));
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
