        public static void Main()
        {
            Information dataInformation =  new Information();
            Write(() => dataInformation);
        }
        static void Write<T>(Expression<Func<T>> expression)
        {
            MemberExpression me = expression.Body as MemberExpression;
            if (me == null) throw new NotSupportedException();
            Console.WriteLine(me.Member.Name);
        }
