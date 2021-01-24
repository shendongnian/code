    public void Slot1Button_Click(object sender, RoutedEventArgs e)
            {
    
                mixerSlot1 = new Potion("", "");
    
                if (selectedPotion.PotionNumber == slot2Label.Content)
                {
                    MessageBox.Show("A potion can not be mixed with itself!", "Help Window", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    mixerSlot1.MyIngredients = selectedPotion.MyIngredients;
                    slot1Label.Content = selectedPotion.PotionNumber;
                }
            }
    
            public void Slot2Button_Click(object sender, RoutedEventArgs e)
            {
                
                mixerSlot2 = new Potion("", "");
    
                if (selectedPotion.PotionNumber == slot1Label.Content)
                {
                    MessageBox.Show("A potion can not be mixed with itself!", "Help Window", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    mixerSlot2.MyIngredients = selectedPotion.MyIngredients;
                    slot2Label.Content = selectedPotion.PotionNumber;
                }
            }
    
            public void MixButton_Click(object sender, RoutedEventArgs e)
            {
                if (mixerSlot1 == null || mixerSlot2 == null)
                {
                    if (mixerSlot1 == null)
                    {
                        MessageBox.Show("Please put a potion to slot 1.", "Help Window", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (mixerSlot2== null)
                    {
                        MessageBox.Show("Please put a potion to slot 2.", "Help Window", MessageBoxButton.OK, MessageBoxImage.Information);
                    }                
                }
                else
            {
                mixerSlot1.MixIngredient(mixerSlot2);
                MessageBox.Show("Selected potions mixed!", "Help Window", MessageBoxButton.OK, MessageBoxImage.Information);
                slot1Label.Content = "...";
                slot2Label.Content = "...";
                RefreshIngredientsList();
            }
