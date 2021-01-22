    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    class Program
    {
        static void Main(string[] args)
        {
            var list = new[]
                           {
                               //new {Name = "ABC", Id = 1},
                               //new {Name = "Xyz", Id = 2}
                               new {Name = "ABC", Id = 1, Foo = 123.22},
                               new {Name = "Xyz", Id = 2, Foo = 444.11}
                           };
            var resultList = DynamicNewTyple(list);
            foreach (var item in resultList)
            {
                Console.WriteLine( item.ToString() );
            }
            Console.ReadLine();
            
        }
        static IQueryable DynamicNewTyple<T>(IEnumerable<T> list)
        {
            // This is basically: list.Select(x=> new Tuple<string, int, ...>(x.Name, x.Id, ...);
            Expression selector = GetTupleNewExpression<T>();
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
            var selectMi = genSelectMi.MakeGenericMethod(new[] {inputType, resultType}); 
            var result = selectMi.Invoke(null, new object[] {list.AsQueryable(), selector});
            return (IQueryable) result;
            
        }
        static Expression GetTupleNewExpression<T>()
        {
            Type paramType = typeof (T);
            string tupleTyneName = typeof (Tuple).AssemblyQualifiedName;
            int propertiesCount = paramType.GetProperties().Length;
            if ( propertiesCount > 8 )
            {
                throw new ApplicationException(
                    "Currently only Tuples of up to 8 entries are alowed. You could change this code to allow stacking of Tuples!");
            }
            // So far we have the non generic Tuple type. 
            // Now we need to create select the correct geneeric of Tuple.
            // There might be a cleaner way ... you could get all types with the name 'Tuple' and 
            // select the one with the correct number of arguments ... that exercise is left to you!
            // We employ the way of getting the AssemblyQualifiedTypeName and add the genric information 
            tupleTyneName = tupleTyneName.Replace("Tuple,", "Tuple`" + propertiesCount + ",");
            var genericTupleType = Type.GetType(tupleTyneName);
            
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
            // Create a type of the discovered tuples
            var tupleType = genericTupleType.MakeGenericType(tupleTypes.ToArray());
            var tuplConstructor =
                tupleType.GetConstructors().First();
            var res =
                Expression.Lambda(
                    Expression.New(tuplConstructor, parmList.ToArray()),
                    argument);
            return res;
        }
    }
