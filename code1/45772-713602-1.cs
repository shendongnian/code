    void FuncB()
    {
        var example = new { Id = 0, Name = string.Empty };
        var obj = EvilCast(FuncA(), example);
        Console.WriteLine(obj.Name);
    }
    object FuncA()
    {
        var a = from e in DB.Entities
                where e.Id == 1
                select new { Id = e.Id, Name = e.Name };
        return a.FirstOrDefault();
    }
    T EvilCast<T>(object target, T example)
    {
        return (T)target;
    }
