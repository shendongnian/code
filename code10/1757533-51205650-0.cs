    [TestMethod]
    public void TestInsertDataFromFile()
    {
        String fileName = @"D:\SampleData.txt";
        String connectionString = @"Server=MyTestDBServer; Database=TestingDatabase; Trusted_Connection=True;";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlTransaction transaction = conn.BeginTransaction())
            {
                String insertCommand = @"INSERT INTO JDVTest (SBSBranchCode, BranchName, FinYear, BrChallanNo, TransDate, MajorHead, ReceiptPayment, Amount, PlanNonPlan) ";
                insertCommand += @"VALUES (@sbsBranchCode, @branchName, @finYear, @brChallanNo, @transDate, @majorHead, @receiptPayment, @amount, @planNonPlan)";
                String[] fileContent = File.ReadAllLines(fileName);
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = insertCommand;
                    command.CommandType = CommandType.Text;
                    command.Transaction = transaction;
                    foreach (String dataLine in fileContent)
                    {
                        String[] columns = dataLine.Split('|');
                        command.Parameters.Clear();
                        command.Parameters.Add("sbsBranchCode", SqlDbType.VarChar).Value = columns[0];
                        command.Parameters.Add("branchName", SqlDbType.VarChar).Value = columns[1];
                        command.Parameters.Add("finYear", SqlDbType.VarChar).Value = columns[2];
                        command.Parameters.Add("brChallanNo", SqlDbType.VarChar).Value = columns[3];
                        command.Parameters.Add("transDate", SqlDbType.VarChar).Value = columns[4];
                        command.Parameters.Add("majorHead", SqlDbType.VarChar).Value = columns[5];
                        command.Parameters.Add("receiptPayment", SqlDbType.VarChar).Value = columns[6];
                        command.Parameters.Add("amount", SqlDbType.VarChar).Value = columns[7];
                        command.Parameters.Add("planNonPlan", SqlDbType.VarChar).Value = columns[8];
                        command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
        }
    }
