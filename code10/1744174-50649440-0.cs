        private static object GetMemberValue(MemberExpression member) {
            var objectMember = Expression.Convert(member, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            return getter();
        }
        public static IQueryable<IGrouping<TKey, TSource>> GroupByDateDiff<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector) {
            var body = (NewExpression)keySelector.Body;
            foreach (var arg in body.Arguments) {
                if (arg.NodeType == ExpressionType.Call) {
                    var callNode = (MethodCallExpression)arg;
                    if (callNode.Method.Name == "DateDiff") {
                        var dateDiffFirstArg = callNode.Arguments[0];
                        if (dateDiffFirstArg.NodeType == ExpressionType.Constant) {
                            //It was already a constant, so we're good.
                        }
                        else {
                            //HACK: This will break if the internal implementation of ReadOnlyCollection changes.
                            var listInfo = typeof(ReadOnlyCollection<Expression>).GetField("list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            var list = (IList)listInfo.GetValue(callNode.Arguments);
                            if (dateDiffFirstArg.NodeType == ExpressionType.MemberAccess) {
                                list[0] = Expression.Constant((string)GetMemberValue((MemberExpression)dateDiffFirstArg));
                            }
                            else {
                                throw new ArgumentException($"{nameof(GroupByDateDiff)} was unable to parse the datePartArg argument to the DateDiff function.");
                            }
                        }
                    }
                }
            }
            return source.GroupBy(keySelector);
        }
