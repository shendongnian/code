        /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ResourceLoader res;
        public Window1()
        {            
            InitializeComponent();
            // load it from WPF Resources 
            this.res = (ResourceLoader)this.FindResource("resource");
            // or create an instance 
            //this.res = new ResourceLoader(CultureInfo.InvariantCulture, "Resource");      
            this.LayoutRoot.DataContext = res;                    
        }
        private void btnSwichLanguage_Click(object sender, RoutedEventArgs e)
        {            
            res.SwitchCulture(new CultureInfo("de"));               
            this.LayoutRoot.DataContext = null;
            this.LayoutRoot.DataContext = res;                      
        }       
    }
