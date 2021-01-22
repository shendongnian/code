        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Data.Common;
        using System.Data;
        using System.Data.Odbc;
        using System.IO;
        using System.Threading;
        namespace DataAccessLayer
        {      
            public class DBManager
            {   
                //FILE LOGGER METHOD
                public  void SqlLogger(string SqlText)
                {  if (!File.Exists("SQL.txt"))
                    {  using (StreamWriter sw = new StreamWriter("SQL.txt"))
                        {   sw.Flush();
                            sw.Close();
                            sw.Dispose();
                        }
                    }
        
                    using (StreamWriter sw = File.AppendText("SQL.txt"))
                    {   sw.WriteLine(SqlText);
                        sw.WriteLine(" ");
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
        
                }
                
                // DATABASE METHODS
                public static OdbcConnection g_con = new OdbcConnection("Dsn=wsodbc1");      
                public DBManager()
                {
        
                }
                public OdbcConnection GetConnection()
                
                {  try   {   g_con.Open();         }
                    catch (Exception ex)     {        }
                    return g_con;            
                }
                public OdbcCommand GetCommand(string Query)
                {
                    OdbcCommand cmd = new OdbcCommand(Query);
                    cmd.Connection = GetConnection();
                    return cmd;
                }
                public void ExeCommand(string Query)
                {
                    OdbcCommand cmd = GetCommand(Query);
                    cmd.ExecuteNonQuery();    
        
                    
                }
                public OdbcDataReader GetReader(string Query)
                {  return GetCommand(Query).ExecuteReader();     }
        
                // SQL INSERT GENERATOR
                public void GenerateSql(string tablename)
                {
                    File.Delete("SQL.txt");
                    List<string> cols = new List<string>();
                    string ColNames;
            
        
                    OdbcDataReader reader = GetReader("SELECT     * FROM         Customers ");
        
                    DataTable schemaTable = reader.GetSchemaTable();
        
                    foreach (DataRow row in schemaTable.Rows)
                    {   foreach (DataColumn column in schemaTable.Columns)
                    {          
                        if (column.ColumnName.Equals("ColumnName")) cols.Add(row[column].ToString().ToUpper());                    
                        }
                    }
                                
        
                        ColNames = string.Join(",", cols.ToArray());
        
        
                        while (reader.Read())
                    {
                            
                        SqlLogger("INSERT INTO " + tablename + " (" + ColNames + ") VALUES (" + Row_Values(reader) + ")");
        
                    }
        
                }
                public string Row_Values(OdbcDataReader r)
                {
                        List<string> colsVals = new List<string>();
        
                        for (int i = 0; i < r.FieldCount; i++ )
                        {
                            
                            if (r[i].GetType().ToString().Equals("System.String"))
                            {
                                if (r[i] == null)
                                {
                                    colsVals.Add("NULL");
                                }
                                else
                                {
                                    colsVals.Add("'" + r[i].ToString().Replace("'","''").Replace(",","-") + "'");
                                }
        
                            }
                            else if (r[i].GetType().ToString().Equals("System.DBNull"))
                            {
                                colsVals.Add("NULL");
                            }
                            else
        
                            {
                                if (r[i] == null)
                                {
                                    colsVals.Add("NULL");
                                }
                                else
                                {
                                    var VAL = r[i].ToString();
                                    colsVals.Add("'" + VAL.ToString().Replace("'", "''").Replace(",", "-") + "'");
                                }
        
                            }
                        }
        
                        return string.Join(",", colsVals.ToArray());   
                }
            }
        }
