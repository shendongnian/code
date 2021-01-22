    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            m_panel.DataContext = new Class1();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Class1)m_panel.DataContext).SomeField = new Class2();
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Class1)m_panel.DataContext).SomeField.AnotherField = "Updated field";
        }
    }
