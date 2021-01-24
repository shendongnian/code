    using System.Linq;
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    
    public class C {
        static Expression<Func<Foo, bool>> InExpression<T>(
            string propertyName,IEnumerable<int> array)
        {
            return x => array.Contains(x.Id);
        }
    }
    
    class Foo {
        public int Id {get;set;}   
    }
