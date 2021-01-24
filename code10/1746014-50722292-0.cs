    public virtual IEnumerable<MyModel> QueryAllById(ICollection<string> ids)
    {
        var sql = mySelectQuery + @"
                        WHERE SomeId IN @Ids                            
                ";            
        return Db.Query<MyModel>(sql, new { Ids = ids.ToArray() });
    }
