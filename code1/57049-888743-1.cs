    using System;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
 
    namespace bo
    {
    class Program
    {
        static private void CreateCSVFile(DataTable dt, string strFilePath)
        {
            #region Export Grid to CSV
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(strFilePath, false);
            int iColCount = dt.Columns.Count;
            
            // First we will write the headers.
            //DataTable dt = m_dsProducts.Tables[0];
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            
            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount -1 )
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            #endregion
        }
        static void Main(string[] args)
        {
            string strConn = "connection string to sql";
            string direktorij = @"d:";
            SqlConnection conn = new SqlConnection(strConn); 
            SqlCommand command = new SqlCommand("sp_ado_pos_data", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add('@skl_id', SqlDbType.Int).Value = 158;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                string datoteka  = (string.Format(@"{0}tablea{1}.csv", direktorij, i));
                DataTable tabela = ds.Tables[i];
                CreateCSVFile(tabela,datoteka );
                Console.WriteLine("Generišem tabelu {0}", datoteka);
            }
            Console.ReadKey();
        }
      }
    }
