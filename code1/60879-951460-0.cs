    public static class EnumerableExtension
    
        {
    
            public static IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> items, string property, bool ascending)
    
            {
    
                var myObject = Expression.Parameter(typeof (T), "MyObject");
    
     
    
                var myEnumeratedObject = Expression.Parameter(typeof (IEnumerable<T>), "MyEnumeratedObject");
    
     
    
                var myProperty = Expression.Property(myObject, property);
    
     
    
                var myLambda = Expression.Lambda(myProperty, myObject);
    
     
    
                var myMethod = Expression.Call(typeof (Enumerable), ascending ? "OrderBy" : "OrderByDescending",
    
                                               new[] {typeof (T), myLambda.Body.Type}, myEnumeratedObject, myLambda);
    
     
    
                var mySortedLambda =
    
                    Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(myMethod, myEnumeratedObject).Compile();
    
     
    
                return mySortedLambda(items);
    
            }
    
        }
 
