    class RunValues
    {
        public int id { get; set; }
        public int runTimeSpan { get; set; }
        public int numberOfRunTime { get; set; }
        public List<int> GetRunValues()
        {
            var values = new List<int>();
            // I'm guessing it needs " where id = @id" here...
            var mySQL = "select RunFreq, RunTimes from IFFRunValues"; 
            using(var myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConn"].ConnectionString))
            {
                using(var myCmd = new SqlCommand(mySQL, myCon))
                {
                    try
                    {
                        myCon.Open();
                        SqlDataReader runValuesReader = myCmd.ExecuteReader();
                        if (runValuesReader.HasRows)
                        {
                            while (runValuesReader.Read())
                            {
                                runTimeSpan = runValuesReader.GetValueOrDefault<int>("RunFreq");
                                numberOfRunTime = runValuesReader.GetValueOrDefault<int>("RunTimes");
                                values.Add(runTimeSpan);
                                values.Add(numberOfRunTime);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var destPath = Path.Combine("C:\\",  "error_log.txt");
                        File.AppendAllText(destPath, ex.Message);
                        values.Clear();
                    }
                }
            }            
            return values;
        }
    }
