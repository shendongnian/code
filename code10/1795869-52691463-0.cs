    public List<TEntity> ReadText()
    {
        return File.ReadAllLines(_txtfile).Select(c =>
        {
            var method = typeof(TEntity).GetMethod("op_Explicit", new[] { typeof(string) });
            return (TEntity) method.Invoke(null, new[] { c });
        }).ToList ();
    }
