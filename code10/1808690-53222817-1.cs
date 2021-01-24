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
      public class Book
      {
          public string Title { get; set; }
          public DateTime End { get; set; }
      }
