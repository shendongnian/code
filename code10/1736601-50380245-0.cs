    namespace grandson
    {
        /// <summary>
        /// Interaction logic for Root.xaml
        /// </summary>
        public partial class Root : UserControl
        {
            public Root()
            {
                InitializeComponent();
            }
    
            public Control Children
            {
                get { return this.ContentControl; }
            }
        }
    }
