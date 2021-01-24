    namespace TestWPF
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
          MainViewModel model;
          public MainWindow()
          {
              InitializeComponent();
              this.Loaded += MainWindow_Loaded;
          }
          private void MainWindow_Loaded(object sender, RoutedEventArgs e)
          {
              model = new MainViewModel();
              model.Load();
              this.DataContext = model;
          }       
      }
      public class MainViewModel
      {
          public ObservableCollection<Book> BookCollection { get; set; }
          public void Load()
          {
              BookCollection = new ObservableCollection<Book>
              {
                  new Book() { Title = "Book One", End = DateTime.Now },
                  new Book() { Title = "Book Two", End = DateTime.Now.AddDays(10) },
                  new Book() { Title = "Book Three", End = DateTime.Now.AddDays(2) }
              };
          }
      }
      public class Book : INotifyPropertyChanged
      {
         private string title;
         private DateTime end;
         public string Title
         {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
         }
         public DateTime End
         {
             get { return end; }
             set
             {
                end = value;
                NotifyPropertyChanged();
             }
          }
          public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
          {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }
          public event PropertyChangedEventHandler PropertyChanged;
       }
      public class DummyConverter : IValueConverter
      {
          public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          {
            if (value == null)
                return null;
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            return string.Join("-", encoding.GetBytes((value as string) ?? string.Empty));
          }
          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
              if (value == null)
                  return null;
              string val = (value as string);
              var array = val.Split('-');
              Byte[] byteArray = new Byte[array.Length];
              for (int i = 0; i < array.Length; i++)
              {
                  Byte.TryParse(array[i], out byte x);
                byteArray[i] = x;
              }
              return Encoding.ASCII.GetString(byteArray);
          }
     }
    } 
