        static void Main(string[] args)
        {
            try
            {
                bool success = true;
                MyData myData = ReadMyDataFromFile();
                try
                {
                    WriteMyDataToDB(myData);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("An error occured saving the data.\n" + ex.Message);
                    success = false;
                }
                WriteLogFile(myData, success);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occured reading the data or writing the log file.\n" + ex.Message);
            }
        }
