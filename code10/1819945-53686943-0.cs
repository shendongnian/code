        public void DrinkButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPotion == null)
            {
                MessageBox.Show("Please select a potion to drink", "Help Window", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                foreach (var recipe in RecipeList)
                {
                    bool equalIngredients = recipe.Recipe.All(selectedPotion.MyIngredients.Contains) && recipe.Recipe.Count == selectedPotion.MyIngredients.Count;
                    if (equalIngredients)
                    {
                        recipe.DrinkEffect();
                        goto NextStep;
                    }
                }
                MessageBox.Show("Doesn't taste like anything!", "Announcement!", MessageBoxButton.OK, MessageBoxImage.Information);
            NextStep: return;
            }
        }
