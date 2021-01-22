    public void FuncB()
    {
        var example = new { Id = 0, Name = string.Empty };
        var obj = CastByExample(FuncA(), example);
        Console.WriteLine(obj.Name);
    }
    private object FuncA()
    {
        var a = from e in DB.Entities
                where e.Id == 1
                select new { Id = e.Id, Name = e.Name };
        return a.FirstOrDefault();
    }
    private T CastByExample<T>(object target, T example)
    {
        return (T)target;
    }
