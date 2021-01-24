       static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            
            var options=new ParallelOptions { MaxDegreeOfParallelism = 500 };
            var watch=Stopwatch.StartNew();
            Parallel.For(0,1000,options,Call);
            Console.WriteLine($"Finished in {watch.Elapsed}");
        }
        public static void Call(int i)
        {            
            var watch = Stopwatch.StartNew();
            
            using (SqlConnection connection = CreateNewConnection())
            {
                try
                {
                    connection.Open();
                    var cmd=new SqlCommand($"SELECT {i}",connection);
                    var selected =cmd.ExecuteScalar();                    
                    Console.WriteLine($"{selected} : {watch.Elapsed}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ooops!: {e}");
                }
            }
        }
        private static SqlConnection CreateNewConnection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                UserID = "someUser",
                Password = "somPassword",                        
                InitialCatalog = "tempdb",
                DataSource = @"localhost",
                MultipleActiveResultSets = true,
                Pooling=true //true by default                
                //MaxPoolSize is 100 by default
            };
            return new SqlConnection(builder.ConnectionString);
        }
    }
