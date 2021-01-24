    public void DrinkButton_Click(object sender, RoutedEventArgs e)
    {
    	foreach (var recipe in RecipeList)
    	{
    		bool equalIngredients = recipe.Recipe.All(selectedPotion.MyIngredients.Contains) &&
    									recipe.Recipe.Count == selectedPotion.MyIngredients.Count;
    
    		if (equalIngredients)
    			recipe.DrinkEffect();
    		else
    			MessageBox.Show("Doesn't taste like anything!", "Announcement!", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
