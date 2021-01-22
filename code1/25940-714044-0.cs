    public sealed class Lambda<T>
    {
        public static Func<T, T> Cast = x => x;
    }
    
    public class Example
    {
        public void Run()
        {
            // Declare
            var c = Lambda<Func<int, string>>.Cast;
            // Use
            var f1 = c(x => x.ToString());
            var f2 = c(x => "Hello!");
            var f3 = c(x => (x + x).ToString());
        }
    }
