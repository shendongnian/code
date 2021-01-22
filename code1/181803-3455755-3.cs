    private static IEnumerable<Func<MyClass, bool>> GetPredicates (int num)
    {
       var predicates = new Func<MyClass, bool>[] {m => m.Foo == 3, m => m.Bar =="x", m => DateTime.Now.DayOfWeek == DayOfWeek.Sunday};
    
       return predicates.Take (num);
    }
