    var _ILike = typeof(NpgsqlDbFunctionsExtensions).GetMethod("ILike", 
                                    BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                                    null, 
                                    new[] { 
                                        typeof(Microsoft.EntityFrameworkCore.DbFunctions),  
                                        typeof(string),  
                                        typeof(string) 
                                    },
                                    null
                                    );
    
    _expr = Expression.Call(
                        _ILike, 
                        Expression.Constant(null, typeof(DbFunctions)), 
                        property, 
                        Expression.Constant(search, typeof(string)));
