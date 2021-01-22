    SqlConnection con = new SqlConnection(@"Data Source=NIKOLAY;Initial Catalog=PlanZadanie;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            public void loadTree(TreeView tree)
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [RAZDEL_ID],[NAME_RAZDEL] FROM [tbl_RAZDEL]";
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tree.Nodes.Add(reader.GetString(1));
                        tree.Nodes[0].Nodes.Add("yourChildNode");
                        tree.ExpandAll();
                      
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка с сообщением: " + ex.Message);
                }
            }
