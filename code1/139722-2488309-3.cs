    public partial class FilteredDataSet : Window
    {
        public FilteredDataSet()
        {
            InitializeComponent();
    
            CreateDataContext();
            MyComboBox.DataContext = MyDataSet.Tables[0];
        }
    
        private DataSet MyDataSet { get; set; }
        private void CreateDataContext()
        {
            var ds = new DataSet();
            var dt = new DataTable( "Adresse" );
            ds.Tables.Add( dt );
    
            var dc = new DataColumn( "AdrLabel" );
            dt.Columns.Add( dc );
    
            DataRow dr = dt.NewRow();
            dr[0] = "one";
            dt.Rows.Add( dr );
    
            dr = dt.NewRow();
            dr[0] = "honed";
            dt.Rows.Add( dr );
    
            dr = dt.NewRow();
            dr[0] = "obiwone";
            dt.Rows.Add( dr );
    
            dr = dt.NewRow();
            dr[0] = "won";
            dt.Rows.Add( dr );
    
            MyDataSet = ds;
    
        }
        private void OnFilterClick( object sender, RoutedEventArgs e )
        {
            string filter = MyFilter.Text;
    
            var context = MyDataSet.Tables[0].AsEnumerable()
                .Where( dr => dr.Field<string>( "AdrLabel" ).Contains( filter ) )
                .Select( dr => dr.Field<string>( "AdrLabel" ) );
          
            MyComboBox.DisplayMemberPath = string.Empty;
    
            MyComboBox.DataContext = context;
        }
    }
