    using System;
    using System.Data;
    using System.Data.SQLite;
    
    namespace SqliteCsv
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // fill your dataset
                QuoteDataSet ds = new QuoteDataSet();
                ds.ReadXml("data.xml", XmlReadMode.InferTypedSchema);
    
    
                int insertedRows;
                using (
                    SQLiteConnection con =
                        new SQLiteConnection(@"data source=C:\Projects\StackOverflowAnswers\SqliteCsv\SqliteCsv\Quotes.db"))
                {
                    con.Open();
    
                    // clear table - you may not want this
                    SQLiteCommand cmd = con.CreateCommand();
                    cmd.CommandText = "delete from Tags";
                    cmd.ExecuteNonQuery();
    
    
                    using (SQLiteTransaction txn = con.BeginTransaction())
                    {
                        using (SQLiteDataAdapter dbAdapter = new SQLiteDataAdapter("select * from Tags", con))
                        {
                            dbAdapter.InsertCommand = new SQLiteCommandBuilder(dbAdapter).GetInsertCommand(true);
                            insertedRows = dbAdapter.Update(ds, "Tags");
                        }
                        txn.Commit();
                    }
                }
                Console.WriteLine("Inserted {0} rows", insertedRows);
    
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
