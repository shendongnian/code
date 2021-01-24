            for (int i = 0; i < gradeAlways.Rows.Count +1; i++)
            {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                        var Mark = dt.Rows[i]["Mark"];
                            marks.Text = Mark.ToString();
                        
                }
