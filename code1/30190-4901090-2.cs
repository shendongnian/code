    public List<T> ToList<T>(Expression<Func<T>> type, string sql, params object[] parameters)
            {
                var expression = (NewExpression)type.Body;
                var constructor = expression.Constructor;
                var members = expression.Members.ToList();
    
                var dataReaderParam = Expression.Parameter(typeof(IDataReader));
                var arguments = members.Select(member => 
                    {
                        var memberName = Expression.Constant(member.Name);
                        return Expression.Call(typeof(Utilities), 
                                               "Get", 
                                               new Type[] { ((PropertyInfo)member).PropertyType },  
                                               dataReaderParam, memberName);
                    }
                ).ToArray();
    
                var body = Expression.New(constructor, arguments);
    
                var mapper = Expression.Lambda<Func<IDataReader, T>>(body, dataReaderParam);
    
                return ToList<T>(mapper.Compile(), sql, parameters);
            }
