    public partial class TreeViewControl : UserControl
    {
        public static RoutedCommand AddCommand { get; private set; }
        
        static TreeViewControl()
        {
            AddCommand = new RoutedCommand("AddCommand", typeof(TreeViewControl));
        }
    
        public TreeViewControl()
        {
            InitializeComponent();
    
            CommandBindings.Add(new CommandBinding(AddCommand, AddExecuted, AddCanExecute));
        }
    
        public void AddExecuted(object sender, ExecutedRoutedEventArgs e)
        {
        }
    
        public void AddCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false; // your logic here
        }
    }
