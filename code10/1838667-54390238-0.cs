    using System;
    using System.Linq;
    
    public class C {
        public void M2() {
            var query =
                new SomeClass[0]
                .AsQueryable()
                .Where(x => x.SomeCollection.Any(y => y % 2 == 0));
        }
        static bool F(System.Linq.Expressions.Expression<Func<int, bool>> e) { return true; }
        
        class SomeClass {
            public IQueryable<int> SomeCollection { get; set; }
        }
    }
