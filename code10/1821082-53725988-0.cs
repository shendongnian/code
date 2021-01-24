    protected void viewAnimalsBreedButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\FrendsWithPaws.mdf;Integrated Security=True");
    
                cnn.Open();
                SqlCommand command = new SqlCommand("SELECT PetID, Breed, Name, Age, Gender, Picture, Sanctuary FROM Pets WHERE Breed='" +  breedDropDownList.SelectedValue + "'", cnn);
                SqlDataReader reader = command.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(dataReader);
                petsGridView.DataSource = dataTable;
                petsGridView.DataBind();
                cnn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }
