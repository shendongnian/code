    using (SqlConnection conn = new SqlConnection(myConnectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from MyTable", conn))
                    {
                        DataTable table = new DataTable();
                        adapter.FillSchema(table, SchemaType.Mapped);
                        //at this point, table will have no rows, but will have all the columns of which you can get their datatypes
                    }
                }
