     public partial class MainWindow : Window
    {
        public ObservableCollection<Note> Notes { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Notes = new ObservableCollection<Note>();
            Notes.Add(new Note(){Title="test", X=100, Y=0});
        }
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Note n = (Note)((FrameworkElement)sender).DataContext;
            n.X += e.HorizontalChange;
            n.Y += e.VerticalChange;
        }
    }
    public class Note : INotifyPropertyChanged
    {
        private string title;
        private double x;
        private double y;
        
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Y"));
            }
        }
        
        public double X
        {
            get { return x; }
            set
            {
                x = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("X"));
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
