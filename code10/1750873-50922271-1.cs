    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;
    namespace WpfApplication6
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>(new[]
            {
                new Item { ExecFileName = @"C:\Temp\icon1.png" },
                new Item { ExecFileName = @"C:\Temp\icon2.png" }
            });
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                FrameworkElementFactory factory = new FrameworkElementFactory(typeof(Image));
                factory.SetBinding(Image.SourceProperty, new Binding("ImageSource"));
                GridView gridView = new GridView();
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "FileName",
                    DisplayMemberBinding = new Binding("ExecFileName")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = "Image",
                    CellTemplate = new DataTemplate() { VisualTree = factory }
                });
                ResultListView.View = gridView;
            }
        }
        public class Item
        {
            public string ExecFileName { get; set; }
            public BitmapImage ImageSource
            {
                get
                {
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(ExecFileName, UriKind.RelativeOrAbsolute);
                    bi.EndInit();
                    return bi;
                }
            }
        }
    }
