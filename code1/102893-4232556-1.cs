    public partial class Form1 : Form
    {
        private CommandManager commandManager;
 
        public ICommand CommandA { get; set; }
        public ICommand CommandB { get; set; }
 
        public bool condition;
 
        public Form1()
        {
            InitializeComponent();
 
            commandManager = new CommandManager();
            
            CommandA = new DelegateCommand("Command 1", OnTrue, OnExecute);
            CommandB = new DelegateCommand("Command 2", OnFalse, OnExecute);
 
            commandManager.Bind(CommandA, button1);
            commandManager.Bind(CommandB, button2);
 
            commandManager.Bind(CommandA, command1ToolStripMenuItem);
            commandManager.Bind(CommandB, command2ToolStripMenuItem);
        }
 
        private bool OnFalse()
        {
            return !condition;
        }
 
        private bool OnTrue()
        {
            return condition;
        }
 
        private void OnExecute()
        {
            condition = !condition;
        }
    }
