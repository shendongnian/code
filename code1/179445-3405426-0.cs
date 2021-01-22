    TestEntity testEntity = new TestEntity() { Name = "Hello World" };
    context.TestEntities.AddObject(testEntity);
    var entitiesInOSM = context.ObjectStateManager.
            GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged).
            Where(ent => ent.Entity is TestEntity).
            Select(ent => ent.Entity as TestEntity);
    Assert.AreEqual(1, entitiesInOSM.Count(), "Entity not in context!");
