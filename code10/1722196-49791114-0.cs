    public class ViewModel
    {
        private readonly IDisplay _display;
        public ViewModel(IDisplay display)
        {
            _display = display;
        }
        public void DoSomething()
        {
            // do something
            _display.ShowMessage("result of do something");
        }
    }
