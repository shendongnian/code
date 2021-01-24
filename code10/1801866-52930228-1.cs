    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window2ViewModel viewModel = new Window2ViewModel();
            Row row = viewModel.Rows.FirstOrDefault();
            if (row != null)
            {
                DataTemplate dataTemplate = dataGrid.Resources["cellTemplate"] as DataTemplate;
                for (int i = 0; i < row.Cells.Length; ++i)
                    dataGrid.Columns.Add(new DataGridTemplateColumn() { CellTemplate = CreateCellTemplate(i), CellStyle = CreateCellStyle(i) });
            }
            DataContext = viewModel;
        }
        private static DataTemplate CreateCellTemplate(int index)
        {
            const string Xaml = " <DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" x:Key=\"cellTemplate\"><CheckBox IsChecked=\"{{Binding Cells[{0}].IsChecked, UpdateSourceTrigger=PropertyChanged}}\" Content=\"Check\" /></DataTemplate>";
            return XamlReader.Parse(string.Format(Xaml, index)) as DataTemplate;
        }
        private static Style CreateCellStyle(int index)
        {
            const string Xaml = "<Style TargetType=\"DataGridCell\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"> " +
                                "     <Style.Triggers> " +
                                "       <DataTrigger Binding=\"{{Binding Cells[{0}].IsChecked}}\" Value=\"True\"> " +
                                "        <Setter Property=\"Background\" Value=\"Red\" /> " +
                                "       </DataTrigger> " +
                                "     </Style.Triggers> " +
                                "</Style>";
            return XamlReader.Parse(string.Format(Xaml, index)) as Style;
        }
    }
