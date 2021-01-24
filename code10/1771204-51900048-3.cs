    namespace WpfApp1.Views
    {
        using System.Windows.Controls;
        using WpfApp1.ViewModels;
    
        /// <summary>
        /// Interaction logic for MultiComboBoxes.xaml
        /// </summary>
        public partial class FeatureView : UserControl
        {
            public FeatureView()
            {
                InitializeComponent();
                this.DataContext = new FeatureViewModel();
            }
        }
    }
