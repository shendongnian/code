    // Enumerable.Any()
    static readonly MethodInfo anyTSource = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                             where x.Name == nameof(Enumerable.Any)
                                             let args = x.GetGenericArguments()
                                             where args.Length == 1
                                             let pars = x.GetParameters()
                                             where pars.Length == 2 &&
                                                 pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                 pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                             select x).Single();
    // Enumerable.Select()
    public static readonly MethodInfo selectTSourceTResult = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                              where x.Name == nameof(Enumerable.Select)
                                                              let args = x.GetGenericArguments()
                                                              where args.Length == 2
                                                              let pars = x.GetParameters()
                                                              where pars.Length == 2 &&
                                                                        pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                        pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                              select x).Single();
