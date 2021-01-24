    var _regex = typeof(System.Text.RegularExpressions.Regex).GetMethod("IsMatch", 
                                    BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
                                    null, 
                                    new[] { 
                                        typeof(string),  
                                        typeof(string),
                                        typeof(System.Text.RegularExpressions.RegexOptions)
                                    },
                                    null
                                    );
    
                            _expr = Expression.Call(_regex, property, Expression.Constant(search, typeof(string)), Expression.Constant(System.Text.RegularExpressions.RegexOptions.IgnoreCase));
                           
