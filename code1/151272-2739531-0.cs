        public void Write<T,U>(T source, Expression<Func<T, U>> lambda, U value) 
        {
            var body = lambda.Body as MemberExpression;
            string memberName = body.Member.Name;
            if (body.Member.MemberType == MemberTypes.Field)
            {
                (body.Member as FieldInfo).SetValue(source, value);
            }
            else if (body.Member.MemberType == MemberTypes.Method)
            {
                (body.Member as MethodInfo).Invoke(source, new object[]{value});
            }
            Console.WriteLine("You wrote to " + memberName + " value " + value);
        }
