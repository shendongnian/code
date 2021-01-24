    public partial class View1 : UserControl
    {
        public View1()
        {
            InitializeComponent();
            Loaded += (s, e) => 
            {
                Window mainWindow = Window.GetWindow(this) as MainWindow;
                if(mainWindow != null)
                    mainWindow.changedText += newWindow_ChangeText;
            };
        }
        void newWindow_ChangeText(object sender, EventArgs e)
        {
            ViewOnelabel.Content = "Happy";
        }
    }
