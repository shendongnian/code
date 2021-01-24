    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace testtestz
    { 
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            protected override void OnContentRendered(EventArgs e)
            {
                base.OnContentRendered(e);
    
                var cBox = new FrameworkElementFactory(typeof(ComboBox));
    
                myGrid.Columns[0].HeaderTemplate = new DataTemplate() { VisualTree = cBox };
            }
        }
    }
