    public Window1()
    {
        InitializeComponent();
        m_panel.DataContext = new Data();
    }
    
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        Data d = m_panel.DataContext as Data;
        d.SomeObjField = new SubData(field1.Text);
    }
    
    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        Data d = m_panel.DataContext as Data;
        d.SomeObjField.AnotherField = field2.Text;
    }
