    using System;
    using System.Linq.Expressions;
    
    namespace YourApp
    {
        public class Tuple<T1, T2>
        {
            public T1 First { get; private set; }
            public T2 Second { get; private set; }
    
            public Tuple(T1 _First, T2 _Second)
            {
                First = _First;
                Second = _Second;
            }
            public override int GetHashCode()
            {
                var hash = 0;
    
                // Implement this however you like
                hash = First.GetHashCode() * 17 + Second.GetHashCode() + First.GetHashCode();
    
                return hash;
            }
            public static bool operator ==(Tuple<T1, T2> x, Tuple<T1, T2> y)
            {
                return PropertyCompare.Equal(x, y);
            }
            public static bool operator !=(Tuple<T1, T2> x, Tuple<T1, T2> y)
            {
                return !PropertyCompare.Equal(x, y);
            }
            public bool Equals(Tuple<T1, T2> other)
            {
                return PropertyCompare.Equal(this, other);
    
            }
            public override bool Equals(object obj)
            {
                return PropertyCompare.Equal(this, obj);
            }
        }
        public static class Tuple
        {
            public static Tuple<T1, T2> New<T1, T2>(T1 first, T2 second)
            {
                var tuple = new Tuple<T1, T2>(first, second);
                return tuple;
            }
        }
    
        public class Program
        {
            public static void Main()
            {
                var bob1 = Tuple.New("a", 1);
                var bob2 = Tuple.New("a", 1);
    
                Console.WriteLine(bob1 == bob2);
                Console.ReadLine();
            }
        }
    
        public static class PropertyCompare
        {
            public static bool Equal<T>(T x, object y) where T : class
            {
                return Cache<T>.Compare(x, y as T);
            }
    
            public static bool Equal<T>(T x, T y)
            {
                if (x == null)
                {
                    return y == null;
                }
    
                if (y == null)
                {
                    return false;
                }
    
                return Cache<T>.Compare(x, y);
            }
    
            private static class Cache<T>
            {
                internal static readonly Func<T, T, bool> Compare;
                static Cache()
                {
                    var props = typeof(T).GetProperties();
                    if (props.Length == 0)
                    {
                        Compare = delegate { return true; };
                        return;
                    }
                    var x = Expression.Parameter(typeof(T), "x");
                    var y = Expression.Parameter(typeof(T), "y");
    
                    Expression body = null;
                    for (var i = 0; i < props.Length; i++)
                    {
                        var propEqual = Expression.Equal(
                            Expression.Property(x, props[i]),
                            Expression.Property(y, props[i]));
                        if (body == null)
                        {
                            body = propEqual;
                        }
                        else
                        {
                            body = Expression.AndAlso(body, propEqual);
                        }
                    }
                    Compare = Expression.Lambda<Func<T, T, bool>>(body, x, y)
                                  .Compile();
                }
            }
        }
    }
