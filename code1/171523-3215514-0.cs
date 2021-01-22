    public interface IMyGeneric {
        Type MyType { get; set;}    
    }
    class MyGeneric<T> : IMyGeneric {
        public MyGeneric() {
            MyType = typeof(T);
        }
        public Type MyType {
            get; set;
        }
    }
