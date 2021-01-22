    public partial class StoredProcedures
    {
        [SqlProcedure()]
        public static void InsertCurrency_CS(
            SqlString currencyCode, SqlString name)
        {
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                SqlCommand InsertCurrencyCommand = new SqlCommand();
                SqlParameter currencyCodeParam = new SqlParameter("@CurrencyCode", SqlDbType.NVarChar);
                SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.NVarChar);
    
    
    
                InsertCurrencyCommand.CommandText =
                    "INSERT Sales.Currency (CurrencyCode, Name, ModifiedDate)" +
                    " VALUES(@CurrencyCode, @Name)";
    
                InsertCurrencyCommand.Connection = conn;
    
                conn.Open();
                InsertCurrencyCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
