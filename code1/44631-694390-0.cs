    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            
            CommandBinding binding = new CommandBinding(ApplicationCommands.Copy);
            binding.Executed += new ExecutedRoutedEventHandler(this.copy_Executed);
            this.CommandBindings.Add(binding);
        }
    
        void copy_Executed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Executed the Copy command");
        }
    } 
