    static void Main(string[] args)
    {
        string str = "User Id=xxx; password=xxx; Data Source=localhost:1521/xxx;";
        string sql = @"DECLARE lvsName VARCHAR2(6) := 'Oracle'; BEGIN  DBMS_OUTPUT.PUT_LINE('Do you see me?'); DBMS_OUTPUT.PUT_LINE('My name is: ' || lvsName); END;";
        OracleConnection _connection = new OracleConnection(str);
        try
        {
            _connection.Open();
            //adapter not being used
            //using (OracleDataAdapter oda = new OracleDataAdapter())
            using (OracleCommand cmd = new OracleCommand(sql, _connection))
            {
                // First enable buffer output
                // Set output Buffer
                cmd.CommandText = "BEGIN DBMS_OUTPUT.ENABLE(NULL); END;";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                // Then execute anonymous block
                // Execute anonymous PL/SQL block
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                var res = cmd.ExecuteNonQuery();
                // Get output
                cmd.CommandText = "BEGIN DBMS_OUTPUT.GET_LINES(:outString, :numLines); END;";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("outString", OracleDbType.Varchar2, int.MaxValue, ParameterDirection.Output));
                cmd.Parameters["outString"].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                cmd.Parameters["outString"].Size = sql.Length;
                cmd.Parameters["outString"].ArrayBindSize = new int[sql.Length];
                // set bind size for each array element
                for (int i = 0; i < sql.Length; i++)
                {
                    cmd.Parameters["outString"].ArrayBindSize[i] = 32000;
                }
                cmd.Parameters.Add(new OracleParameter("numLines", OracleDbType.Int32, ParameterDirection.InputOutput));
                cmd.Parameters["numLines"].Value = 10; // Get 10 lines
                cmd.ExecuteNonQuery();
                int numLines = Convert.ToInt32(cmd.Parameters["numLines"].Value.ToString());
                string outString = string.Empty;
                // Try to get more lines until there are zero left
                while (numLines > 0)
                {
                    for (int i = 0; i < numLines; i++)
                    {
                        // use proper indexing here
                        //OracleString s = (OracleString)cmd.Parameters["outString"].Value;
                        OracleString s = ((OracleString[])cmd.Parameters["outString"].Value)[i];
                        outString += s.ToString();
                        // add new line just for formatting
                        outString += "\r\n";
                    }
                    cmd.ExecuteNonQuery();
                    numLines = Convert.ToInt32(cmd.Parameters["numLines"].Value.ToString());
                }
                Console.WriteLine(outString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        _connection.Close();
        _connection.Dispose();
        Console.WriteLine("Press RETURN to exit.");
        Console.ReadLine();
    }
