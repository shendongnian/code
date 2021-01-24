    var recipesJoin = (
                  from a in db.IngredientsToRecipes
                  join b in db.Recipes on a.recipeID equals b.recipeID
                  join c in db.Ingredients on a.siin equals c.siin
                  select new
                  {
                      recipeID = a.recipeID,
                      userID = b.userID,
                      name = b.name,
                      description = b.description,
                      price = c.price
                  }).GroupBy(x => x.recipeID) // 1
                  .Select(grp=> new //2
                  {
                      recipeID = grp.Key,
                      name= grp.First().name, // same ID => same name anyway
                      toalPrice = grp.Sum(b => b.price) //3
                  })
                  .Where(y => y.totalPrice < 2000); //4
