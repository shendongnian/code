        using System;
        using System.Windows;
        using System.Windows.Input;
        namespace WpfApp1
        {
            /// <summary>
            ///     Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    // Wire up CancelAction in the View
                    var windowToClose = new Window();
                    var castedContext = (ViewModel) DataContext;
                    castedContext.CancelAction = () => windowToClose.Close();
                }
            }
            public class ViewModel
            {
                private ICommand _doSomethingCommand;
                public Action CancelAction { get; set; }
                public ICommand DoSomethingCommand
                {
                    get
                    {
                        if (_doSomethingCommand != null)
                            return _doSomethingCommand;
                        _doSomethingCommand = new MyCommandImplementation(() =>
                        {
                            // Perform Logic
                            // If need to cancel - invoke cancel action
                            CancelAction.Invoke();
                        });
                        return _doSomethingCommand;
                    }
                }
            }
            // Stubbed out for the sake of complete code
            public class MyCommandImplementation : ICommand
            {
                public MyCommandImplementation(Action action)
                {
                    throw new NotImplementedException();
                }
                public bool CanExecute(object parameter)
                {
                    throw new NotImplementedException();
                }
                public void Execute(object parameter)
                {
                    throw new NotImplementedException();
                }
                public event EventHandler CanExecuteChanged;
            }
        }
