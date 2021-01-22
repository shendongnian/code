    public class DbTestDataRepository : ITestDataRepository
    {
        const string InsertionQuery = @"INSERT INTO TEST (TESTDATA) VALUES (?)";
    
        public void Add(TestData data)
        {
    
            using (OleDbConnection conn = DbUtil.GetConnection())
            using (OleDbCommand command = new OleDbCommand(InsertionQuery, conn))
            {
                command.Parameters.Add("@p1", OleDbType.BSTR).Value = data.SomeData;
    
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // perhaps log something?
                }
            }
        }
    
    }
