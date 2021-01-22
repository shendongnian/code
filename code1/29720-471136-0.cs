    public abstract class ReadTextFile : ILoadable
    {
        public string Path { get; set; }
        public UploadFileType FileType { get; set; }
        protected internal List<List<string>> Table { get; set; }
        public Guid BatchID { get; set; }
    
        /// <summary>
        /// Method that loads the raw text into a collection of strings
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            Table = new List<List<string>>();
            var splitter = Convert.ToChar("\t");
            try
            {
                using (TextReader tr = new StreamReader(Path))
                {
                    // Discard the first line
                    String line = tr.ReadLine();
    
                    // Read and display lines from the file until the end of the file is reached.
                    while ((line = tr.ReadLine()) != null)
                    {
                        Table.Add(line.Split(splitter).ToList<string>());
                    }
                    tr.Close();
                    tr.Dispose();
                }
                return true;
    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }
    }
