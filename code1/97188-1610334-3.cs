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
            private static DataTable OpenCSVasDBWithLockWontWork(string fullFileName, out OleDbDataReader reader)
            {
                string file = Path.GetFileName(fullFileName);
                string dir = Path.GetDirectoryName(fullFileName);
                string cStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                    + "Data Source=\"" + dir + "\\\";"
                    + "Extended Properties=\"text;HDR=Yes;FMT=Delimited\";";
                string sqlStr = "SELECT * FROM [" + file + "]";
                OleDbConnection openConnection = new OleDbConnection(cStr);
                reader = null;
                DataTable dt = new DataTable();
                try
                {
                    openConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(sqlStr, openConnection);
                    reader = cmd.ExecuteReader();
                    dt.Load (reader);       // this will close the reader and unlock the file!
                    return dt;  
                }
                catch 
                { 
                    return null; 
                }
            }
            private static void OpenCSVasDBWithLock(string fullFileName, Action<IDataReader> dataRowProcessor)
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
                            dataRowProcessor(reader);
                        }
                    }
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
                        File.OpenRead(fullFileName);   // should throw an exception
    
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
    
                OpenCSVasDBWithLock(filename, delegate(IDataReader row)
                {
                    StringBuilder b = new StringBuilder();
                    for (int i = 0; i <row.FieldCount; i++)
                    {
                        b.Append(row[i].ToString());
                        b.Append(",");
                    }
                    string line = b.ToString().Substring(0, b.Length - 1);
                    Console.WriteLine(line);
                });
    
            }
        }
    }
