    using System;
    using System.Linq.Expressions;
    class Foo {
        public int? Bar { get; set; }
    
        static void Main() {
            var param = Expression.Parameter(typeof(Foo), "foo");
            Expression member = Expression.PropertyOrField(param, "Bar");
            Type typeIfNullable = Nullable.GetUnderlyingType(member.Type);
            if (typeIfNullable != null) {
                member = Expression.Call(member,"GetValueOrDefault",Type.EmptyTypes);
            }
            var body = Expression.Lambda<Func<Foo, int>>(member, param);
            
            var func = body.Compile();
            int result1 = func(new Foo { Bar = 123 }),
                result2 = func(new Foo { Bar = null });    
        }
    }
