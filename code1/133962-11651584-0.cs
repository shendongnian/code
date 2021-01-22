    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    namespace TestReadCfg
    {
      class Program
      {
        static void Main(string[] args)
        {
            string connectionString =
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
            + "c:\\Avtron\\addapt\\Configuration\\testDao.db;Jet OLEDB:Database Password=RainbowTrout;";
            string queryString = "SELECT * from Sections order by Address";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                OleDbCommand command = new OleDbCommand(queryString, connection);
                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    int iRecNbr = 1;
                    while (reader.Read())
                    {
                        String sRecord = string.Empty;
                        sRecord = string.Format("Record {0}: ", iRecNbr);
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sRecord += string.Format("{0} ", reader[i].ToString());
                        }
                        Console.WriteLine(sRecord);
                        iRecNbr++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
       }
    }
