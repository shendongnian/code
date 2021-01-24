    public partial class Form1 : Form
    {
        public NotifyProperty<string> A { get; } = new NotifyProperty<string>();
        public NotifyProperty<double> B { get; } = new NotifyProperty<double>();
        public void Reset()
        {
            A.Value = "Something";
            B.Value = 3.14d;
        }
        public Form1()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", A, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", B, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            Reset();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
    public class NotifyProperty<T> : INotifyPropertyChanged
    {
        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (_value != null && _value.Equals(value)) return;
                _value = value; 
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Value"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
