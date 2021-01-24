    public partial class MainWindow : Window
    {
        private MySqlDataAdapter myDataAdapter;        
        private DataSet myDataSet;
        private MySqlCommandBuilder myBuilder;
        private MySqlConnection myConn = DBUtils.GetDBConnection();
        public MainWindow()
        {
            InitializeComponent();
            myConn.Open();
            myDataAdapter = new MySqlDataAdapter {SelectCommand=new MySqlCommand() {Connection=myConn, CommandText= "SELECT * FROM brands" } };
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "brands");           
            dtGrid.DataContext = myDataSet.Tables["brands"].DefaultView;
        }
        private void dtGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            myBuilder  = new MySqlCommandBuilder(myDataAdapter) { QuotePrefix="[", QuoteSuffix="]"};
            DataRowView myDRV = (DataRowView)dtGrid.SelectedItem;
            myDRV.BeginEdit();
        }
        private void dtGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DataRowView myDRV = (DataRowView)dtGrid.SelectedItem;
            myDRV.EndEdit();
            myDataAdapter.UpdateCommand = myBuilder.GetUpdateCommand();
            myDataAdapter.Update(myDataSet, "brands");
        }
        private void dtGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var tc = e.Column as System.Windows.Controls.DataGridTextColumn;
            var b = tc.Binding as System.Windows.Data.Binding;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.ValidatesOnDataErrors = true;
            b.NotifyOnValidationError = true;
        }
    }
