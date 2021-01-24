     var list = new List<TestEntity>();
            list.Add(new TestEntity { EntityId = 1, EntityName = "aaa" });
            list.Add(new TestEntity { EntityId = 2, EntityName = "bbb" });
            //Creating context on-demand with any available objects rather than external resources (database, file etc.)
            foreach (var item in list)
            {
                var context = new DataContext(item.EntityName);
                context.CreateDatabase();
            }
