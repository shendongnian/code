    if (dateEdit1.EditValue == null || textEdit11.EditValue == null || textEdit10.EditValue == null || comboBox1.Text == null
          || textEdit12.EditValue == null || dateEdit2.EditValue == null || textEdit12.EditValue == null || comboBox2.Text == null
          || comboBox2.Text == null || textEdit14.EditValue == null || textEdit15.EditValue == null || textEdit16.EditValue == null
          || textEdit17.EditValue == null || textEdit18.EditValue == null || comboBox5.Text == null || textEdit19.EditValue == null)
    {
        XtraMessageBox.Show("Please submit the record");
    }
    else
    {
        DialogResult dialog = XtraMessageBox.Show("Are you sure you want to remove this record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (dialog == DialogResult.OK)
        {
            String st = "DELETE FROM OutPatient WHERE OutPatientID =" + textEdit8.Text;
            SqlCommand com = new SqlCommand(st, con);
            con.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                con.Close();
            }
            ClearOutPatient();
        }
        else if (dialog == DialogResult.Cancel)
        {
            ClearOutPatient();
        }
