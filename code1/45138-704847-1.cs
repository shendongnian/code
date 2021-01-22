    namespace Silverlight.Mine
    {
        public partial class Page : UserControl
        {
            private SomeType m_mySomeType = new SomeType();
            public Page()
            {
                InitializeComponent();
                myTextBlock.DataContext = m_mySomeType;
            }
        }
    }
