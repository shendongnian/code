    using System;
    using System.Linq.Expressions;
    
    public class Report {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        static void Main() {
            Report a = new Report { Id = 1, ProjectId = 13 },
                b = new Report { Id = 1, ProjectId = 13 },
                c = new Report { Id = 1, ProjectId = 12 };
            Console.WriteLine(PropertyCompare.Equal(a, b));
            Console.WriteLine(PropertyCompare.Equal(a, c));
        }
    }
    static class PropertyCompare {
        public static bool Equal<T>(T x, T y) {
            return Cache<T>.Compare(x, y);
        }
        static class Cache<T> {
            internal static readonly Func<T, T, bool> Compare;
            static Cache() {
                var props = typeof(T).GetProperties();
                if (props.Length == 0) {
                    Compare = delegate { return true; };
                    return;
                }
                var x = Expression.Parameter(typeof(T), "x");
                var y = Expression.Parameter(typeof(T), "y");
    
                Expression body = null;
                for (int i = 0; i < props.Length; i++) {
                    var propEqual = Expression.Equal(
                        Expression.Property(x, props[i]),
                        Expression.Property(y, props[i]));
                    if (body == null) {
                        body = propEqual;
                    } else {
                        body = Expression.AndAlso(body, propEqual);
                    }
                }
                Compare = Expression.Lambda<Func<T, T, bool>>(body, x, y)
                              .Compile();
            }
        }
    }
