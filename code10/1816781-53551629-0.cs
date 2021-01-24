    using (var context = new TestContext())
    {
        context.Entry(person).State = EntityState.Modified;
        context.Entry(person.Class).State = EntityState.Added;
        context.SaveChanges();
    }
