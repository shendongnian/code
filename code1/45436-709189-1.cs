     public partial class Page : UserControl
     {
          private TestClass m_testClass = new TestClass();
          public Page()
          {
               InitializeComponent();
               myTextBox.DataContext = m_testClass;
          }
      }
