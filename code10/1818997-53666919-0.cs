    class Potion 
    public void MixIngredient(Potion toAddPotion)
            {
                if (MyIngredients.Count < 4)
                {
                    for (int i = 0; i < toAddPotion.MyIngredients.Count; i++)
                    {
                        if (MyIngredients.Count < 4)
                        {
                            Ingredients item = toAddPotion.MyIngredients[i];
                            MyIngredients.Add(item);
                            toAddPotion.MyIngredients.Remove(item);
                        }                    
                    }  
                }          
            }
