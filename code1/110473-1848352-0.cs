    public class DisposableList<T> : List<T>, IDisposable where T : IDisposable {
        
        // any constructors you need...
        public void Dispose() {
            foreach (T obj in this) {
                obj.Dispose();
            }
        }
    }
