        public void ColumnIDPulling()
        {
            int Column;
            try
            {
                string query, id, selection = "NM";
                conn = new SqlConnection(@"Data Source=MIRAZ-PC\SQLEXPRESS;Initial Catalog=ClassRoutine_1;Integrated Security=True");
                conn.Open();
                query = "select PreferredTimeSlot1 from RoutineInfo where TeacherInitials = 'NM'";
                id = new SqlCommand(query, conn).ExecuteScalar().ToString();
                if (id != null)
                {
                    textBox1.Text = id;
                    query = string.Format("select ordinal_position from information_schema.columns c where table_name = 'FinalRoutine' and table_schema = 'dbo' and column_name ='{0}'",id);
                    //string query = ("select ordinal_position from information_schema.columns c where table_name = 'FinalRoutine' and table_schema = 'dbo' and column_name =[9:15-10:30]");
                    reader = new SqlCommand(query, conn).ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Column = reader.GetInt32(0);
                            textBox1.Text = Convert.ToString(Column);
                            // textBox1.Text = Convert.ToString(id);
                        }
                    }
                    else
                    {
                        textBox1.Text = "NF";
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (conn != null) conn.Close();
        }
