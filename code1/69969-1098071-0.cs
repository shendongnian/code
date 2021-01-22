    foreach (var i in new[] {
                               new{Dude=john, Booze=beer, Food=nachos},
                               new{Dude=bob, Booze=cider, Food=chips}
                            })
    {
            if (i.Dude != designatedDriver)
            {
                    i.Booze.Open();
                    i.Dude.Drink(i.Booze);
                    i.Dude.Eat(i.Food);
            }
    }
