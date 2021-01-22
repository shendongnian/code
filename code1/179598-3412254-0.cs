	dt.RowChanged += new DataRowChangeEventHandler(_update_fields);
        private void _update_fields(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                if (e.Action == DataRowAction.Add)
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT IDENT_CURRENT('" + e.Row.Table.TableName + "')";
                    dt.Rows[dt.Rows.Count - 1][0] = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
                    dt.AcceptChanges();
                    conn.Close();
                }
                adapt.Update(dt);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
