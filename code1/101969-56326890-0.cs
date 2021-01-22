        public static string GetMemberPath(MemberExpression me)
        {
            var parts = new List<string>();
            while (me != null)
            {
                parts.Add(me.Member.Name);
                me = me.Expression as MemberExpression;
            }
            parts.Reverse();
            return string.Join(".", parts);
        }
