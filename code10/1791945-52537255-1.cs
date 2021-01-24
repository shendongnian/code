    using System.Windows;
    using System.Windows.Controls;
    
    
    namespace scrollviewerShyHeader
    {
        public partial class MainWindow : Window
        {
            private void ScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                var vm = (ViewModel)this.DataContext;
                vm.ScrollViewerOffset = e.VerticalOffset;
            }
        }
    }
