    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Model = new Model();
    
                DataContext = Model;
            }
    
            private Model Model { get; }
    
            private void Whatever()
            {
                var value = Model.Value;
            }
        }
    
        internal class Model
        {
            public int Value { get; set; }
        }
    }
