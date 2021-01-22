    // assumes existing collections called "boozes" "dudes" and "foods"
    var qry = from booze in boozes
              from dude in dudes
              from food in foods
              select new {
                   Dude = dude,
                   Booze = booze,
                   Food = food
              };
    
    foreach(var item in qry)
    {
        if(!item.Dude.IsDesignatedDriver)
        {
            item.Booze.Open();
            item.Food.Cook();
            item.Dude.Drink(item.Booze);
            item.Dude.Eat(item.Food);
        }
    }
