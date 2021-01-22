        //TODO: replace with 'nameof' in C# 6
        public static void DebugTrace(this ILog log, params Expression<Func<object>>[] args)
        {
            #if DEBUG
            var method = (new StackTrace()).GetFrame(1).GetMethod();
            var parameters = new List<string>();
            foreach(var arg in args)
            {
                MemberExpression memberExpression = null;
                if (arg.Body is MemberExpression)
                    memberExpression = (MemberExpression)arg.Body;
                if (arg.Body is UnaryExpression && ((UnaryExpression)arg.Body).Operand is MemberExpression)
                    memberExpression = (MemberExpression)((UnaryExpression)arg.Body).Operand;
                parameters.Add(memberExpression == null ? "NA" : memberExpression.Member.Name + ": " + arg.Compile().DynamicInvoke().ToString());
            }
            log.Debug(string.Format("Method '{0}' parameters {1}", method.Name, string.Join(" ", parameters)));
            
            #endif
        }
