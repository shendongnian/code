    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            Commands.Add(new Commander() { DisplayName = "DN1" });
            Commands.Add(new Commander() { DisplayName = "DN2" });
            Commands.Add(new Commander() { DisplayName = "DN3" });
            this.DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
        }
        private ObservableCollection<Commander> commands = new ObservableCollection<Commander>();
        public ObservableCollection<Commander> Commands {
            get { return commands; }
            set { commands = value; }
        }
    }
    public class Commander {
        public ICommand Command { get; set; }
        public string DisplayName { get; set; }
    }
