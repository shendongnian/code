    public class StockItem
    {
      private const string conStringLocal = "Data Source=TestDatabase.sqlite;Version=3;";
    
      private readonly SqlCommand stockCommand;
      private readonly SqlDataAdapter stockAdapter;
      private readonly SqlCommandBuilder stockBuilder;
      private readonly DataSet stockDs;
      private readonly DataTable stockTable;
    
      public DataGridView StockDataGridView { get; }
    
      public StockItem(string item)
      {
        StockDataGridView = new DataGridView();
        StockDataGridView.KeyDown += new KeyEventHandler(stock_KeyDown);
    
        string queryItemStock = "SELECT id_stock, item_name, size, quantity "
          + "FROM Stock WHERE item_name = '" + item + "'";
        SqlConnection con = new SqlConnection(conStringLocal);
    
        stockCommand = new SqlCommand(queryItemStock, con);
        stockAdapter = new SqlDataAdapter(stockCommand);
        stockBuilder = new SqlCommandBuilder(stockAdapter);
        stockDs = new DataSet();
        stockAdapter.Fill(stockDs, "Stock");
        stockTable = stockDs.Tables["Stock"];
        con.Close();
        StockDataGridView.DataSource = stockTable;
      }
    
      private void stock_KeyDown(object sender, KeyEventArgs e)
      {
        DataGridView stock = (DataGridView)sender;
    
        if (e.KeyCode == Keys.Enter)
        {
          // Check different conditions and update if everything is good
          using (SqlConnection con = new SqlConnection(conStringLocal))
          {
            con.Open();
  
            stockAdapter.Update(stockTable);
            MessageBox.Show("Saved changes");
          }
        }
      }
    }
