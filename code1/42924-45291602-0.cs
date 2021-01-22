    /// <summary>
        /// Get properties separated by , (Ex: to invoke 'd => new { d.FirstName, d.LastName }')
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string GetFields<T>(Expression<Func<T, object>> exp)
        {
            MemberExpression body = exp.Body as MemberExpression;
            var fields = new List<string>();
            if (body == null)
            {
                NewExpression ubody = exp.Body as NewExpression;
                if (ubody != null)
                    foreach (var arg in ubody.Arguments)
                    {
                        fields.Add((arg as MemberExpression).Member.Name);
                    }
            }
            return string.Join(",", fields);
        }
