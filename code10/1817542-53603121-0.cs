    private void button0_Click(object sender, RoutedEventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataRowView dataRowView = Ep.SelectedItem as DataRowView;
            cmd =  new SqlCommand("UPDATE Employee SET Name = @Name, LastName = @LastName, Age = @Age, Dep_nt = @Dep_nt, Profession = @Profession, Salary = @Salary WHERE ID = @ID", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@ID", dataRowView.Row["Id"] as Nullable<int>);
            cmd.Parameters.AddWithValue("@Name", NameF.Text);
            cmd.Parameters.AddWithValue("@LastName", LastNameF.Text);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(AgeF.Text)); 
            cmd.Parameters.AddWithValue("@Dep_nt", DepartmentF.Text);
            cmd.Parameters.AddWithValue("@Profession", ProfessionF.Text);
            cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(SalaryF.Text));
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adapter.UpdateCommand = cmd;
            adapter.Fill(dt);
            Ep.ItemsSource = dt.DefaultView;
            connection.Close();
        }
    }
