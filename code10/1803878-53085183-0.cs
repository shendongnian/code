          public IActionResult RecipeList()
        {
            var ls = new List<Recipes>();
            SqlConnection connection = GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select distinct recipes.name, recipes.instructions from recipes;");
                    cmd.Connection = connection;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    connection.Close();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var recipe = new Recipes();
                        recipe.Name = Convert.ToString(dr["name"]);
                        recipe.IngredientName = RecipeIngredientsList(recipe.Name);
                        recipe.Instructions = Convert.ToString(dr["instructions"]);
                        ls.Add(recipe);
                    }
                       
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return View(ls);
        }
        public List<string> RecipeIngredientsList(string Name)
        {
            List<string> ingredients = new List<string>();
            SqlConnection connection = GetConnection();
            try
            {
               using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select ingredients.name " +
                                                    "from ingredients, recipe_ingredients, recipes " +
                                                    "where recipes.id = recipe_ingredients.recipe_id and recipe_ingredients.ingredient_id = ingredients.id and recipes.name = @Name;");
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Connection = connection;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    connection.Close();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ingredients.Add(Convert.ToString(dr["name"]) + "\n");
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return ingredients;
        }
