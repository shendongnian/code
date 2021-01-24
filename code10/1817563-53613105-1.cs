    public partial class Window1 : Window
    {
        public MyModel Model { get; set; }
        public Window1()
        {
            InitializeComponent();
            // Only time creating an instance of MyModel
            Model = new MyModel();
            Model.MyProperties = string.Empty;
            // Pass reference of MyModel to other Windows (or even better ViewModels)
            Window2 wnd = new Window2(Model);
            wnd.Show();
            MessageBox.Show(Model.MyProperties);
            // Output: "This is an example."
        }
    }
  
  
