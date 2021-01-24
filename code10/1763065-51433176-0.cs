    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
        }
        private void Calculate(object sender, System.EventArgs e)
        {
            ViewModel viewModel = BindingContext as ViewModel;
            viewModel.Answer = viewModel.Num1 + viewModel.Num2;
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _num1;
        public double Num1
        {
            get { return _num1; }
            set
            {
                if (_num1 == value)
                    return;
                _num1 = value;
                OnPropertyChanged(nameof(Num1));
            }
        }
        private double _num2;
        public double Num2
        {
            get { return _num2; }
            set
            {
                if (_num2 == value)
                    return;
                _num2 = value;
                OnPropertyChanged(nameof(Num2));
            }
        }
        private double _answer;
        public double Answer
        {
            get { return _answer; }
            set
            {
                if (_answer == value)
                    return;
                _answer = value;
                OnPropertyChanged(nameof(Answer));
            }
        }
        protected void OnPropertyChanged(string propertyname) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
    }
