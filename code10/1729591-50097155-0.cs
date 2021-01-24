    public class GameWindow
    {
        private Frame _mainFrame;
        public GameWindow(Frame mainFrame)
        {
           _mainFrame = frame;
        }
        private void SetSomeValuesAndNavigateToAnotherPage()
        {
            //...
            _mainFrame.Navigate(new SomePage(_mainFrame));
        }
    }
