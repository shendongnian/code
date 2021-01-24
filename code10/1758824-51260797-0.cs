    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Assign Target property Value
            try
            {
                TextBox tb =
                    (TextBox) GridView1.Rows[e.RowIndex].FindControl("TargetTextBox"); //finds the target column
                Target = int.Parse((tb.Text));
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                using (DataManager dmgr = new DataManager())
                {
                    dmgr.Connect("PRODUCTION");
                    dmgr.PackingShiftTargetUpdate(id, Target);
                    dmgr.Disconnect();
                }
                GridView1.EditIndex = -1;
                RefreshGrid(ProductShortDesc);
                DataBind();
            }
            catch (SqlException msg)
            {
                throw new Exception("Input error:", msg);
            }
            catch (Exception ex)
            {
                throw new Exception("Only a Number input is allowed:", ex);
            }
        }
