     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Field> fields = new List<Field> {
                new Field{ ColumnID="Name", Value="Kamran" , RowNumber=1},
                new Field{ ColumnID="Age", Value=25 , RowNumber = 1},
                new Field{ ColumnID="Name", Value="Asim", RowNumber = 2, },
                new Field{ ColumnID="Age", Value=30 , RowNumber = 2 },
                new Field{ ColumnID="Department", Value="Computer" , RowNumber = 2},
            };
            var result = fields.ToPivotArray(item => item.ColumnID, item => item.RowNumber, items => items.FirstOrDefault()?.Value);
            string json = JsonConvert.SerializeObject(result, new KeyValuePairConverter());
            var obj = JArray.Parse(json);
            testGrid.ItemsSource = obj;
        }
    }
    public static class Extension
    {
        public static dynamic[] ToPivotArray<T, TColumn, TRow, TData>(this IEnumerable<T> source, Func<T, TColumn> columnSelector,
                                                                       Expression<Func<T, TRow>> rowSelector, Func<IEnumerable<T>, TData> dataSelector)
        {
            var arr = new List<object>();
            var cols = new List<string>();
            String rowName = ((MemberExpression)rowSelector.Body).Member.Name;
            var columns = source.Select(columnSelector).Distinct();
            //cols = (new[] { rowName }).Concat(columns.Select(x => x.ToString())).ToList();
            cols = (columns.Select(x => x.ToString())).ToList();
            var rows = source.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 Key = rowGroup.Key,
                                 Values = columns.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     r => columnSelector(r),
                                     (c, columnGroup) => dataSelector(columnGroup))
                             }).ToArray();
            foreach (var row in rows)
            {
                var items = row.Values.Cast<object>().ToList();
                // items.Insert(0, row.Key);
                var obj = GetAnonymousObject(cols, items);
                arr.Add(obj);
            }
            return arr.ToArray();
        }
        private static dynamic GetAnonymousObject(IEnumerable<string> columns, IEnumerable<object> values)
        {
            IDictionary<string, object> eo = new ExpandoObject() as IDictionary<string, object>;
            int i;
            for (i = 0; i < columns.Count(); i++)
            {
                eo.Add(columns.ElementAt<string>(i), values.ElementAt<object>(i));
            }
            return eo;
        }
    }
    public class Field
    {
        public string ColumnID { get; set; }
        public object Value { get; set; }
        public int RowNumber { get; set; }
    }
