public List<Field> GetAllByTaskId(string Input)
{
    using (var db = new AutoPrintDbContext())
    {
        return db.Fields.Where(x => x.TaskItemId == Input).ToList();
    }
}
public Field Get(string Input)
{
    using (var db = new AutoPrintDbContext())
    {
        return db.Fields.SingleOrDefault(u => u.Id == Input);
    }
}
public bool Delete(string Input)
{
    try
    {
        using (var db = new AutoPrintDbContext())
        {
            var f = db.Fields.Single(u => u.Id == Input);
            db.Fields.Remove(f);
            db.SaveChanges();
        }
        return true;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
}
If you want to better understand the Entity Framework, I strongly recommend you to go over the following link:
https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper
  [1]: https://docs.microsoft.com/en-us/ef/ef6/fundamentals/performance/perf-whitepaper#2-cold-vs-warm-query-execution
