    String sql;
    int parameterCounter;
    SqlParameter parameter;
    private void delete_Click(object sender, EventArgs e)
    {
        sql = "delete from tabl where id in (";
        parameterCounter = 0;
        using (SqlConnection cn = new SqlConnection("....")) {
        using (SqlCommand cmd = new SqlCommand(sql, cn)) {
        foreach (DataGridViewRow item in advancedDataGridView1.Rows) {
         if (bool.Parse(item.Cells[0].Value.ToString())) {
            parameterCounter++;
            parameter = new SqlParameter();
            parameter.ParameterName = "@par" + parameterCounter.ToString();
            parameter.DbType = System.Data.DbType.Int32;
            parameter.Value = item.Cells[1].Value;
            cmd.Parameters.Add(parameter);
            sql = sql + $"{parameter.ParameterName},";
            // collecting all ids
         }
      }
      sql = sql.TrimEnd(',');
      sql = sql + ")";
      cmd.CommandText = sql;
      cmd.Connection = cn;
      cn.Open();
      cmd.ExecuteNonQuery();
        MessageBox.Show("Successfully Deleted....");
    }
