    using System;
    using System.Data.SqlClient;
    namespace NerdDinner
    {
        public class Class1
        {
            public void Execute()
            {
                SqlConnection readerConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
                readerConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT DinnerID, EventDate FROM Dinners", readerConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                SqlConnection writerConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
                writerConnection.Open();
                SqlCommand writerCommand = new SqlCommand("", writerConnection);
                while (reader.Read())
                {
                    int DinnerID = reader.GetInt32(0);
                    DateTime EventDate = reader.GetDateTime(1);
                    writerCommand.CommandText = "UPDATE Dinners SET EventDate = '" + EventDate.AddDays(1).ToString() + "' WHERE DinnerID = " + DinnerID.ToString();
                    writerCommand.ExecuteNonQuery();
                }
            }
        }
    }
