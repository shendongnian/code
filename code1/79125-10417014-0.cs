       public void insert_dataset(DataSet ds,string ret_table, string table, string fileds, ArrayList arr_data)
        {
            ArrayList arr_rec=new ArrayList();
            string[] str_fields = fileds.Split(',');
            for (int i=0;i<ds.Tables[ret_table].Rows.Count;i++)
            {
                for (int j = 0; j < str_fields.Length; j++)
                {
                    arr_rec.Add(ds.Tables[ret_table].Rows[i].ItemArray[j]);
                }
                insert_table(table, fileds, arr_rec);
                arr_rec.Clear();
            }
          
        }
        public void insert_table(string table,string fileds,ArrayList arr_data)
        {
            string str_command, str_params;
            string[] str_fields = fileds.Split(',');
            for (int i = 0; i < str_fields.Length; i++)
            {
                str_fields[i] = "@" + str_fields[i].Trim();
            }
            str_params = string.Join(",", str_fields);
            str_command = "INSERT INTO " + table + "(" + fileds + ") values(" + str_params + ")";
            con = new OleDbConnection();
            //for sql
            //con=new SqlConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + frm_main.cur_directory + "\\db_temp1.mdb;Persist Security Info=True";
            //for sql
            //con.ConnectionString="server=(local);trusted_connection=yes;database=telephon;";
            cmd = con.CreateCommand();
            //for sql
            //cmd=new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText =str_command;
           // cmd.Parameters.AddWithValue("@ACagname", "2");
           for (int i = 0; i < arr_data.Count; i++)
            {
                cmd.Parameters.AddWithValue(str_fields[i],arr_data[i]);
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
