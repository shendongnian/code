    public class Type1 { }
    public class Type2 { }
    public class Generic<T> { }
    public class Program
    {
        public static void Main()
        {
            var typeName = nameof(Type1);
            switch (typeName)
            {
                case nameof(Type1):
                    var type1 = new Generic<Type1>();
                    // do something
                    break;
                case nameof(Type2):
                    var type2 = new Generic<Type2>();
                    // do something
                    break;
            }
        }
    }
