    public partial class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            KeyBinding kb = new KeyBinding { Key = Key.T, Command = MyCommand };
            InputBindings.Add(kb);
        }
        public List<InputBinding> InputBindings { get; } = new List<InputBinding>();
        public ICommand MyCommand => ...
    }
