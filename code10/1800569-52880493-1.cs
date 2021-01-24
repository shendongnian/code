    var ingredients= new Ingredient []
            {
                new Ingredient { Name = "Ingredient name",  
                     Amount = [your amount], Unit = "[ your unit ]"  },
                 new Ingredient {......................}
             }
           foreach (Ingredient ingredient in ingredients)
            {
                context.Ingredient.Add(ingredient);
            }
            context.SaveChanges();
