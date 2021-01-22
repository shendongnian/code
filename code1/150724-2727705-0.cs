    IQueryable<Object> objectCollection = dataContext.Repository<Object>();
    int amountToSkip = 0;
    IList<Object> objects = objectCollection.Skip(amountToSkip).Take(250).ToList();
    Item item = null;
    while (objects.Count != 0)
            {
                using (dataContext = new LinqToSqlContext(new DataContext()))
                {
                    foreach (Object objectRecord in objects)
                    {
                        // Create 0 - 4 Random Items
                        for (int i = 0; i < Random.Next(0, 4); i++)
                        {
                            item = new Item();
                            item.Id = Guid.NewGuid();
                            item.Object = objectRecord.Id;
                            item.Created = DateTime.Now;
                            item.Changed = DateTime.Now;
                            dataContext.InsertOnSubmit(item);
                        }
                    }
                    dataContext.SubmitChanges();
                }
                amountToSkip += 250;
                objects = objectCollection.Skip(amountToSkip).Take(250).ToList();
            }
