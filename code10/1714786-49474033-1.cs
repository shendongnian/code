    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            KB = new ButtonText();
        }
    
        public ButtonText KB { get; }
    
    }
    public class ButtonText
    {
        public string Text
        {
            get
            {
                return "Button";
            }
        }
    }
