    public interface IXyzable { void xyz(); }
    public class MyGenericClass<T> : IXyzable where T : IXyzable {
        T obj;
        public void xyz() {
            obj.xyz();
        }
    }
