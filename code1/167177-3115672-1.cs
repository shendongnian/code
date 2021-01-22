    public class MainViewModel : ViewModelBase
    {
      public MainViewModel()
      {
         GoCommand = new DelegateCommand<object>(OnGoCommand, CanGoCommand);
         LoadCommands();
      }
      private List<MyCommand> _commands = new List<MyCommand>();
      public List<MyCommand> Commands
      {
         get { return _commands; }
      }
      private void LoadCommands()
      {
         MyCommand c1 = new MyCommand { Command = GoCommand, Parameter = "1", Text = "Menu1", Checked = true};
         MyCommand c2 = new MyCommand { Command = GoCommand, Parameter = "2", Text = "Menu2", Checked = true };
         MyCommand c3 = new MyCommand { Command = GoCommand, Parameter = "3", Text = "Menu3", Checked = false };
         MyCommand c4 = new MyCommand { Command = GoCommand, Parameter = "4", Text = "Menu4", Checked = true };
         MyCommand c5 = new MyCommand { Command = GoCommand, Parameter = "5", Text = "Menu5", Checked = false };
         _commands.Add(c1);
         _commands.Add(c2);
         _commands.Add(c3);
         _commands.Add(c4);
         _commands.Add(c5);
      }
      public ICommand GoCommand { get; private set; }
      private void OnGoCommand(object obj)
      {
      }
      private bool CanGoCommand(object obj)
      {
         return true;
      }
    }
