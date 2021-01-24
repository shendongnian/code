       public static List<string> SplitConnectionString(string ConnectionString)
        {
            try
            {
                List<string> lstConnStrData = new List<string>();
                string[] aryConnStrData = new string[1];
                aryConnStrData = ConnectionString.Split(';');
                // Now loop over the array that holds the conn str data and split each item on "=",
                // and add the second splitted item to the list, so at the end the list will contains 
                // the values of the connection string.
                for (int i = 0; i <= aryConnStrData.Length - 2; i++)
                {
                    lstConnStrData.Add(aryConnStrData[i].Split('=')[1]);
                }
                return lstConnStrData;
            }
            catch (Exception)
            {
                throw;
            }
        }
