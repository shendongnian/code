    using System.Windows;
    using System.Windows.Controls;    
    using System.Data;
    using System.Data.SqlClient;
    
    namespace testApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private SqlDataAdapter myDataAdapter;
            private DataView myDataView;
            private DataSet myDataSet;
            private SqlCommandBuilder myBuilder;
            private SqlConnection myConn = new SqlConnection("CONNECTIONSTRING");
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                myConn.Open();
                myDataAdapter = new SqlDataAdapter {SelectCommand=new SqlCommand() {Connection=myConn, CommandText="SELECT MINumber, CompanyName FROM EIncCompanies WHERE CompanyName LIKE 'Test%'" } };
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "EIncCompanies");
                myDataView = new DataView(myDataSet.Tables["EIncCompanies"]);
                dtGrid.DataContext = myDataView;
            }
    
            private void dtGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
            {
                myBuilder  = new SqlCommandBuilder(myDataAdapter) { QuotePrefix="[", QuoteSuffix="]"};
                DataRowView myDRV = (DataRowView)dtGrid.SelectedItem;
                myDRV.BeginEdit();
            }
    
            private void dtGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
            {
                DataRowView myDRV = (DataRowView)dtGrid.SelectedItem;
                myDRV.EndEdit();
                myDataAdapter.UpdateCommand = myBuilder.GetUpdateCommand();
                myDataAdapter.Update(myDataSet, "EIncCompanies");
            }
    
        }
    }
