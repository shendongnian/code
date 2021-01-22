    int amountToSkip = 0;
    var finished = false;
    while (!finished)
    {
          using (var dataContext = new LinqToSqlContext(new DataContext()))
          {
               var objects = dataContext.Repository<Object>().Skip(amountToSkip).Take(250).ToList();
               if (objects.Count == 0)
                    finished = true;
               else
               {
                    foreach (Object object in objects)
                    {
                        // Create 0 - 4 Random Items
                        for (int i = 0; i < Random.Next(0, 4); i++)
                        {
                            Item item = new Item();
                            item.Id = Guid.NewGuid();
                            item.Object = object.Id;
                            item.Created = DateTime.Now;
                            item.Changed = DateTime.Now;
                            dataContext.InsertOnSubmit(item);
                         }
                     }
                     dataContext.SubmitChanges();
                }
                // Cumulate amountToSkip with processAmount so we don't go over the same Items again
                amountToSkip += processAmount;
            }
    }
