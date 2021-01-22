    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(StringPredicate(c => Char.IsDigit(c)));
            var func = StringPredicate(c => Char.IsDigit(c)).Compile();
            Console.WriteLine(func("h2ello"));
            Console.WriteLine(func("2ello"));
        }
    
        public static Expression<Func<string,bool>> StringPredicate(Expression<Func<char,bool>> pred) {
            Expression<Func<string, char>> get = s => s.First();
            var p = Expression.Parameter(typeof(string), "s");
            return Expression.Lambda<Func<string, bool>>(
                Expression.Invoke(pred, Expression.Invoke(get, p)),
                p);
        }
    }
