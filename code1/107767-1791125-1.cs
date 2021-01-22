    namespace DataAdapterSample
    {
        using System;
        using System.Data;
        using System.Data.SqlClient;
    
        class Program
        {
            static void Main(string[] args)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=[your server];Initial Catalog=[your database];Integrated Security=true;"))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        dataAdapter.SelectCommand = new SqlCommand("select Foo, Bar from dbo.Foos", connection);
                        dataAdapter.InsertCommand = new SqlCommand("insert into dbo.Foos (Foo, Bar) values (@Foo, @Bar)", connection);
                        dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("Foo", SqlDbType.Int, 4, "Foo"));
                        dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("Bar", SqlDbType.NText, 50, "Bar"));
    
                        using (DataSet dataSet = new DataSet())
                        {
                            dataAdapter.Fill(dataSet);
    
                            Console.WriteLine("There are {0} rows in the table", dataSet.Tables[0].Rows.Count);
    
                            DataRow newRow = dataSet.Tables[0].NewRow();
                            newRow["Foo"] = 5;
                            newRow["Bar"] = "Hello World!";
                            dataSet.Tables[0].Rows.Add(newRow);
    
                            dataAdapter.Update(dataSet);
                        }                
    
                        //Just to prove we inserted
                        using (DataSet newDataSet = new DataSet())
                        {
                            dataAdapter.Fill(newDataSet);
                            Console.WriteLine("There are {0} rows in the table", newDataSet.Tables[0].Rows.Count);                
                        }                
                    }
                }
                Console.ReadLine();        
            }
        }
    }
