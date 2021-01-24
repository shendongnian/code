    class DBConnection
    {
        public int Flag { get; private set; }
    
        public SqlConnection Connection { get; private set; }
    
        public DBConnection()
        {
            Connection = new SqlConnection("Data Source=DESKTOP-J3KOF5O;Initial Catalog=besmontedental;Integrated Security=True");
    
            try
            {
                Connection.Open();
                Flag = 1;
            }
            catch (Exception e)
            {
                Flag = 0;
    
                MessageBox.Show(e.Message);
            }
        }
    }
