    // convert textbox values to proper datatypes
    string parmP1Value = textBox1.Text;
    int parmP2Value = int.Parse(textBox2.Text);
    DateTime parmP3Value = DateTime.Parse(textBox3.Text);
    int parmP4Value = int.Parse(textBox4.Text);
    // create and load parameters
    command.Parameters.AddRange(new[]
                                {
                                    new SqlParameter
                                    {
                                        ParameterName = "@p1",
                                        SqlDbType = SqlDbType.NVarChar,
                                        Direction = ParameterDirection.Input,
                                        Size = 100,
                                        Value = parmP1Value
                                    },
                                    new SqlParameter
                                    {
                                        ParameterName = "@p2",
                                        SqlDbType = SqlDbType.Int,
                                        Direction = ParameterDirection.Input,
                                        Value = parmP2Value
                                    },
                                    new SqlParameter
                                    {
                                        ParameterName = "@p3",
                                        SqlDbType = SqlDbType.DateTime,
                                        Direction = ParameterDirection.Input,
                                        Value = parmP3Value
                                    },
                                    new SqlParameter
                                    {
                                        ParameterName = "@p4",
                                        SqlDbType = SqlDbType.Int,
                                        Direction = ParameterDirection.Input,
                                        Value = parmP4Value
                                    }
                                }
                               );
