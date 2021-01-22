    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    using System.Data;
    using System.IO;
    
    namespace TextFileLocking
    {
        class Program
        {
            private static DataTable OpenCSVasDB(string fullFileName)
            {
                string file = Path.GetFileName(fullFileName);
                string dir = Path.GetDirectoryName(fullFileName);
                string cStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source=\"" + dir + "\\\";"
                    + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
                string sqlStr = "SELECT * FROM [" + file + "]";
                OleDbDataAdapter da;
                DataTable dt = new DataTable();
                try
                {
                    da = new OleDbDataAdapter(sqlStr, cStr);
                    da.Fill(dt);
                }
                catch { dt = null; }
                
                return dt;
            }
            private static DataTable OpenCSVasDBWithLock(string fullFileName, out OleDbConnection openConnection)
            {
                string file = Path.GetFileName(fullFileName);
                string dir = Path.GetDirectoryName(fullFileName);
                string cStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source=\"" + dir + "\\\";"
                    + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
                string sqlStr = "SELECT * FROM [" + file + "]";
                OleDbDataAdapter da;
                openConnection = new OleDbConnection(cStr);
                openConnection.Open();
                DataTable dt = new DataTable();
                try
                {
                    da = new OleDbDataAdapter(sqlStr, openConnection);
                    da.Fill(dt);
                }
                catch { dt = null; }
    
                return dt;
    
            }
            private static void OpenCSVasDBWithLock2(string fullFileName, Action<DataTable> dataTableProcessor)
            {
                string file = Path.GetFileName(fullFileName);
                string dir = Path.GetDirectoryName(fullFileName);
                string cStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source=\"" + dir + "\\\";"
                    + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
                string sqlStr = "SELECT * FROM [" + file + "]";
                using (OleDbConnection openConnection = new OleDbConnection(cStr))
                {
                    openConnection.Open();  // closed at the end of the using{} block
                    OleDbDataAdapter da = new OleDbDataAdapter(sqlStr, openConnection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataTableProcessor(dt);     // process the data
                }
            }
            private static void VerifyFileLockedByOleDB(string fullFileName)
            {
                string file = Path.GetFileName(fullFileName);
                string dir = Path.GetDirectoryName(fullFileName);
                string cStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source=\"" + dir + "\\\";"
                    + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
                string sqlStr = "SELECT * FROM [" + file + "]";
                using (OleDbConnection conn = new OleDbConnection(cStr))
                {
                    OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            File.OpenRead(fullFileName);   // should throw an exception
    
                            StringBuilder b = new StringBuilder();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                b.Append(reader.GetValue(i));
                                b.Append(",");
                            }
                            string line = b.ToString().Substring(0, b.Length - 1);
                            Console.WriteLine(line);
                        }
                    }
                }
            }
    
            static void Main(string[] args)
            {
                string filename = Directory.GetCurrentDirectory() + "\\SomeText.CSV";
                try
                {
                    VerifyFileLockedByOleDB(filename);
                }
                catch { }   // ignore exception due to locked file
    
                OleDbConnection openConnection = null;
                DataTable dt = OpenCSVasDBWithLock(filename, out openConnection);
                using (openConnection)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        StringBuilder b = new StringBuilder();
                        foreach (var col in row.ItemArray)
                        {
                            b.Append(col.ToString());
                            b.Append(",");
                        }
                        string line = b.ToString().Substring(0, b.Length - 1);
                        Console.WriteLine(line);
                    }
                }
    
                OpenCSVasDBWithLock2(filename, delegate(DataTable dt2)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        StringBuilder b = new StringBuilder();
                        foreach (var col in row.ItemArray)
                        {
                            b.Append(col.ToString());
                            b.Append(",");
                        }
                        string line = b.ToString().Substring(0, b.Length - 1);
                        Console.WriteLine(line);
                    }
    
                });
    
            }
        }
    }
