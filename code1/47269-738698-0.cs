    public virtual T GetById(short id)
                {
                    var itemParameter = Expression.Parameter(typeof(T), "item");
                    var whereExpression = Expression.Lambda<Func<T, bool>>
                        (
                        Expression.Equal(
                            Expression.Property(
                                itemParameter,
                                GetPrimaryKeyName<T>()
                                ),
                            Expression.Constant(id)
                            ),
                        new[] { itemParameter }
                        );
                    var table = DB.GetTable<T>();
                    return table.Where(whereExpression).Single();
                }
    
    
    public string GetPrimaryKeyName<T>()
                {
                    var type = Mapping.GetMetaType(typeof(T));
        
                    var PK = (from m in type.DataMembers
                              where m.IsPrimaryKey
                              select m).Single();
                    return PK.Name;
                }
