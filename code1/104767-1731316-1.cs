    public class Foo<T>
    {
        static Foo()
        {
            // one of the following depending on what you're trying to do
            if (typeof(A).IsAssignableFrom(typeof(T)))
            {
                throw new NotSupportedException(string.Format(
                    "Generic type Foo<T> cannot be instantiated with {0} because it derives from or implements {1}.",
                    typeof(T),
                    typeof(A)
                    ));
            }
            if (typeof(T) == typeof(A))
            {
                throw new NotSupportedException(string.Format(
                    "Generic type Foo<T> cannot be instantiated with type {0}.",
                    typeof(A)
                    ));
            }
        }
    }
