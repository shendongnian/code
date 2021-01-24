using System.ComponentModel;
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string output;
    public string Output
    {
        get { return output; }
        set
        {
            output = value;
            OnPropertyChanged(); // notify the GUI that something has changed
        }
    }
    public MainWindow()
    {
        this.DataContext = this;
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
    }
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Output = "Hallo";
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName: propertyName));
        }
    }
}
The XAML code would look like this:
