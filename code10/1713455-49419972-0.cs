    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString)) {
            using (SqlCommand command = connection.CreateCommand()) {
                command.Text = "UPDATE EMPLOYEES SET Attendance = 'Present' WHERE EMP_ID = @id";
                command.Parameters.AddWithValue("@id", txtText.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
