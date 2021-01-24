    public class Foo<T>
    {
        static void Bar()
        {
            // This is fine, but is not what you're looking for - it uses
            // the type parameter T as the type argument
            List<CommonProperty<T>> list = new List<CommonProperty<T>>();
        }
    }
