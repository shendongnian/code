          public static Dictionary < string, Func<string, parameters, IDataReader> dbMethods = 
                               new Dictionary<string, Func<string, parameters, IDataReader>();
             public static void CreateMethodDictionary()
             {                
                dbMethods.Add(CommandType.StoredProcedure, GetReaderByProc);
                dbMethods.Add(CommandType.Text, GetReaderByText);
             }
