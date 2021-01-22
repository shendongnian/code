    static void Main(string[] args)
        {
            Boolean PrevSqlError = false;
            Boolean NewSqlPool = false;
            String ConStr = "Data Source=SQL-CLUSTER1;Initial Catalog=Example;Integrated Security=True;Connection Timeout=60;Min pool size=5";
            Console.WriteLine("Press any key to read from database");
            Console.ReadKey();
            while (true)
            {
                try
                {
                    Console.WriteLine("Attempting to connect");
                  
                    using (var context1 = new ExampleDataContext())
                    {
                        var customers1 = context1.Customers.ToList();
                        var connection1 = new SqlConnection(ConStr);
                        connection1.Open();
                        PrintCustomers(customers1);
                        connection1.Close();
                    }
                    PrevSqlError = false;
                    NewSqlPool = false;
                    Console.WriteLine("Sleeping 3s");
                    Thread.Sleep(3000);
                }
                catch (SqlException sqlException)
                {
                    var SqlError = sqlException.Number;
                    Console.WriteLine("Error connecting to SQL : " + SqlError+" : "+sqlException.Message);
                    if (NewSqlPool == true)
                    {
                        Console.WriteLine("Error in New Connection Pool. Exiting!");
                        Thread.Sleep(10000);
                        return;
                    }
                    if (PrevSqlError == true)
                    {
                        if (SqlError == 10054 || SqlError == 232 || SqlError == 233 || SqlError == 64 || SqlError == 4060)
                        {
                            Console.WriteLine("SQL Cluster Failing Over. Waiting 5s");
                            SqlConnection.ClearAllPools();
                            PrevSqlError = false;
                            NewSqlPool = true;
                            Thread.Sleep(5000);
                        }
                        else
                        {
                            Console.WriteLine("Fatal SQL Exception. Exiting!");
                            Thread.Sleep(10000);
                            return;
                        }
                    }
                    else
                    {
                    Console.WriteLine("SQL Error, Retrying in 3s");
                    PrevSqlError = true;
                    Thread.Sleep(3000);
                    }
                }
            }
        }
        private static void PrintCustomers(List<Customer> customers)
        {
            foreach (var item in customers)
            {
                Console.WriteLine(string.Format("{0} - {1}", item.Id, item.Name));
            }
        }
