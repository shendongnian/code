    public static string ToCsv<T>(this IEnumerable<T> list, List<string> keyIndicators,
        List<string> inTreatmentCohorts)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            //Setup expression constants
            var param = Expression.Parameter(type, "x");
            var doublequote = Expression.Constant("\"");
            var doublequoteescape = Expression.Constant("\"\"");
            var comma = Expression.Constant(",");
            MethodCallExpression[] propq = { };
            var propqList = new List<MethodCallExpression>();
            var columnNames = new List<string>();
            //Convert all properties to strings, escape and enclose in double quotes
            foreach (var keyIndicator in keyIndicators)
            {
                foreach (var inTreatmentCohort in inTreatmentCohorts)
                {
                    propq = (from prop in props
                        let tostringcall = Expression.Call(Expression.Property(param, prop),
                            prop.ReflectedType.GetMethod("ToString", new Type[0]))
                        let replacecall = Expression.Call(tostringcall,
                            typeof(string).GetMethod("Replace", new[] {typeof(string), typeof(string)}), doublequote,
                            doublequoteescape)
                        where prop.Name.Contains(keyIndicator) && prop.Name.Contains(inTreatmentCohort)
                        select Expression.Call(
                            typeof(string).GetMethod("Concat", new[] {typeof(string), typeof(string), typeof(string)}),
                            doublequote, replacecall, doublequote)
                    ).ToArray();
                    var columnNameQuery = (from prop in props
                        where prop.Name.Contains(keyIndicator) && prop.Name.Contains(inTreatmentCohort)
                        select prop.Name);
                    columnNames.AddRange(columnNameQuery);
                    propqList.AddRange(propq);
                }
            }
            propq = propqList.ToArray();
            var concatLine = propq[0];
            for (var i = 1; i < propq.Length; i++)
                concatLine =
                    Expression.Call(
                        typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string), typeof(string) }),
                        concatLine, comma, propq[i]);
            var method = Expression.Lambda<Func<T, string>>(concatLine, param).Compile();
            var header = string.Join(",", columnNames.ToArray());
            return header + Environment.NewLine + string.Join(Environment.NewLine, list.Select(method).ToArray());
        }
