    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            var list = new[]
                           {
                               // You can uncomment the lines below and comment the next ones
                               // though you cannot mix the two!
                               //new {Name = "ABC", Id = 1},
                               //new {Name = "Xyz", Id = 2}
                               new {Name = "ABC", Id = 1, Foo = 123.22},
                               new {Name = "Xyz", Id = 2, Foo = 444.11}
                           };
            var resultList = DynamicCreateTuple(list);
            foreach (var item in res2)
            {
                Type type = item.GetType();
                Console.WriteLine( item.ToString() );
            }
            Console.ReadLine();
            
        }
        static IQueryable DynamicCreateTuple<T>(IEnumerable<T> list)
        {
            // This is basically: list.Select(x=> Tuple.Create(x.Name, x.Id, ...);
            Expression selector = GetTupleCreateExpression<T>();
            var expressionType = selector.GetType();
            var funcType = expressionType.GetGenericArguments()[0]; // == Func< <>AnonType..., Tuple<String, int>>
            var funcTypegenericArguments = funcType.GetGenericArguments();
            var inputType = funcTypegenericArguments[0];  // == <>AnonType...
            var resultType = funcTypegenericArguments[1]; // == Tuple<String, int>
            
            var selects = typeof (Queryable).GetMethods()
                .AsQueryable()
                .Where(x => x.Name == "Select"
                );
            // This is hacky, we just hope the first method is correct, 
            // we should explicitly search the correct one
            var genSelectMi = selects.First(); 
            var selectMi = genSelectMi.MakeGenericMethod(new Type[] {inputType, resultType}); 
            var result = selectMi.Invoke(null, new object[] {list.AsQueryable(), selector});
            return (IQueryable) result;
            
        }
        static Expression GetTupleCreateExpression<T>()
        {
            Type paramType = typeof (T);
            
            MethodInfo[] tupleCreateMethods = typeof(Tuple).GetMethods()
                .Where(x => x.Name == "Create").ToArray(); 
            MethodInfo tupleCreateMethod =
                tupleCreateMethods.Where(x => x.GetParameters().Length == paramType.GetProperties().Length).
                    FirstOrDefault();
            var argument = Expression.Parameter(paramType, "x");
            var parmList = new List<Expression>();
            List<Type> tupleTypes = new List<Type>();
            //we add all the properties to the tuples, this only will work for up to 8 properties (in C#4)
            // We probably should use our own implementation.
            // We could use a dictionary as well, but then we would need to rewrite this function 
            // more or less completly as we would need to call the 'Add' function of a dictionary.
            foreach (var param in paramType.GetProperties())
            {
                parmList.Add(Expression.Property(argument, param));
                tupleTypes.Add(param.PropertyType);
            }
            tupleCreateMethod = tupleCreateMethod.MakeGenericMethod(tupleTypes.ToArray());
            var res =
                Expression.Lambda(
                    Expression.Call(tupleCreateMethod, parmList.ToArray()),
                    argument);
            return res;
        }
    }
