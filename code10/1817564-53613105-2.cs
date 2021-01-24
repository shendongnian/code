    public partial class Window2 : Window
    {
        // Don't create another instance, just pass the existing instance reference
        public MyModel Model { get; set; }
        public Window2(MyModel model)
        {
            InitializeComponent();
            Model = model;
            // Modifying Properties from here will also update in Window1
            Model.MyProperties = "This is an example.";
        }
    }
