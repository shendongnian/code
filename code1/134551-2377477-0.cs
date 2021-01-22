    using System;
    using System.Linq.Expressions;
    
    class Person
    {
        public DateTime Birthday { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            Person jon = new Person 
            { 
                Birthday = new DateTime(1976, 6, 19)
            };
            
            Expression<Func<Person,DateTime>> dateTimeExtract = p => p.Birthday;
            var monthExtract = ExtractMonth(dateTimeExtract);
            var compiled = monthExtract.Compile();
            Console.WriteLine(compiled(jon));
        }
        
        static Expression<Func<T,int>> ExtractMonth<T>
            (Expression<Func<T,DateTime>> existingFunc)
        {
            Expression func = Expression.Property(existingFunc.Body, "Month");
            Expression<Func<T, int>> lambda = 
                Expression.Lambda<Func<T, int>>(func, existingFunc.Parameters);
            return lambda;
        }                                        
    }
