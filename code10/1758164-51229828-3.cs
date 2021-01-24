    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    namespace WpfApplication11
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new WindowViewModel(this);
            }
        }
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class WindowViewModel : ViewModelBase
        {
            private string _test;
            public WindowViewModel(MainWindow mainWindow)
            {
                Test = "Hello";
            }
            public string Test
            {
                get
                {
                    return _test;
                }
                set
                {
                    if (_test != value)
                    {
                        _test = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            public CloseCommand CloseCommand { get; set; } = new CloseCommand();
        }
        public class CloseCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            public MainWindow mainWindow { get; set; }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                MessageBox.Show("Press OK to close");
                ((Window)parameter).Close();
            }
        }
    }
