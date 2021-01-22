    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;    
    using GalaSoft.MvvmLight.Messaging;
    class CloseWindowMsg
    {
    }
    // View
    public partial class TestCloseWindow : Window
    {
        public TestCloseWindow() {
            InitializeComponent();
            Messenger.Default.Register<CloseWindowMsg>(this, (msg) => Close());
        }
    }
    // View Model
    public class MainViewModel: ViewModelBase
    {
        ICommand _closeChildWindowCommand;
        public ICommand CloseChildWindowCommand {
            get {
                return _closeChildWindowCommand?? (_closeChildWindowCommand = new RelayCommand(() => {
                    Messenger.Default.Send(new CloseWindowMsg());
            }));
            }
        }
    }
