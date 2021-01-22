    public partial class MyCustomControl : IDisposable
        {
    
            public MyCustomControl() {
                InitializeComponent();
    
                Loaded += delegate(object sender, RoutedEventArgs e) {
                    System.Windows.Window parent_window = Window.GetWindow(this);
                    if (parent_window != null) {
                        parent_window.Closed += delegate(object sender2, EventArgs e2) {
                            Dispose();
                        };
                    }
                };
                
                ...
                
            }
            
            ...
        }
