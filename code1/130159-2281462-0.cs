    public Expresssion<Func<SomeEntity, bool>> GeneratePredicate
    {
         return e => e.Id == 123;
    }
    public Expression<Func<SomeEntity, T>> GenerateSelector<T>()
    {
         return e => e.GroupField;
    }
