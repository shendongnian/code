        using (SqlConnection con = new SqlConnection(@"Data Source=MYDATASOURCE"))
        {
           using(SqlCommand cmd = new SqlCommand(
    "Insert into [Voorraad] values(@IngredientID, @AantalInVoorraad, @MinimumVoorraad", con))
           {
               cmd.Parameters.AddWithValue("@IngredientID", txt_ID.Text);
               cmd.Parameters.AddWithValue("@AantalInVoorraad", txt_aantal.Text);
               cmd.Parameters.AddWithValue("@MinimumVoorraad", txt_minimum.Text);
               cmd.Connection.Open()
               cmd.ExecuteNonQuery();
           }
        
           using(SqlCommand cmd = new SqlCommand(
    "insert into [Ingredient] values(@IngredientID, @IngredientNaam";, con))
           {
              cmd.Parameters.AddWithValue("@IngredientID", txt_ID.Text);
              cmd.Parameters.AddWithValue("@IngredientNaam", txt_ingredient.Text);
              cmd.Connection.Open()
              cmd.ExecuteNonQuery();
           }
        }
               
