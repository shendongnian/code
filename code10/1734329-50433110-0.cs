    static readonly MethodInfo allTSource = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                             where x.Name == nameof(Enumerable.All)
                                             let args = x.GetGenericArguments()
                                             where args.Length == 1
                                             let pars = x.GetParameters()
                                             where pars.Length == 2 &&
                                                 pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                 pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], typeof(bool))
                                             select x).Single();
