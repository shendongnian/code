    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    namespace MyNamespace
    {
        public static class DbmsOutputHelper
        {
            public const int DefaultReadBatchSize = 10;
            public static void EnableDbmsOutput(this OracleConnection conn)
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DBMS_OUTPUT.ENABLE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            public static void DisableDbmsOutput(this OracleConnection conn)
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DBMS_OUTPUT.DISABLE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            public static List<string> ReadDbmsOutput(this OracleConnection conn, int readBatchSize = DefaultReadBatchSize)
            {
                if (readBatchSize <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(readBatchSize), "must be greater than zero");
                }
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DBMS_OUTPUT.GET_LINES";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var linesParam = cmd.Parameters.Add(new OracleParameter("lines", OracleDbType.Varchar2, int.MaxValue, ParameterDirection.Output));
                    linesParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    linesParam.Size = readBatchSize;
                    linesParam.ArrayBindSize = Enumerable.Repeat(32767, readBatchSize).ToArray();   // set bind size for each array element
                    var numLinesParam = cmd.Parameters.Add(new OracleParameter("numlines", OracleDbType.Int32, ParameterDirection.InputOutput));
                    var result = new List<string>();
                    int numLinesRead;
                    do
                    {
                        numLinesParam.Value = readBatchSize;
                        cmd.ExecuteNonQuery();
                        numLinesRead = ((OracleDecimal)numLinesParam.Value).ToInt32();
                        var values = (OracleString[])linesParam.Value;
                        for (int i = 0; i < numLinesRead; i++)
                        {
                            result.Add(values[i].ToString());
                        }
                    } while (numLinesRead == readBatchSize);
                    return result;
                }
            }
        }
    }
