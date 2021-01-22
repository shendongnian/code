    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication5
    {
      public partial class Window1 : Window
      {
        public Window1()
        {
          InitializeComponent();
        }
    
        private void ToggleHeaderClick(object sender, RoutedEventArgs e)
        {
          var tabControlVM =
            ((FrameworkElement)sender).DataContext as TabControlViewModel;
          if (tabControlVM != null)
          {
            tabControlVM.TabHeaderVisible = !tabControlVM.TabHeaderVisible;
          }
        }
      }
    
      public class TabControlViewModel : INotifyPropertyChanged
      {
        private bool _tabHeaderVisible = true;
    
        public ICommand ToggleHeader
        {
          get; private set;
        }
    
        public bool TabHeaderVisible
        {
          get { return _tabHeaderVisible; }
          set
          {
            _tabHeaderVisible = value;
            OnPropertyChanged("TabHeaderVisible");
          }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChanged(string name)
        {
          var changed = PropertyChanged;
          if (changed != null)
          {
            changed(this, new PropertyChangedEventArgs(name));
          }
        }
      }
    }
