    public interface IMyInterface<T> {
    }
    public class Foo { }
    public class Bar { }
    public class MyClass {
        Dictionary<Type, object> myInterfaces = new Dictionary<Type, object>();
        public IMyInterface<Foo> Foos {
            get { return (IMyInterface<Foo>)myInterfaces[typeof(Foo)]; }
            set { myInterfaces[typeof(Foo)] = value; }
        }
        public IMyInterface<Bar> Bars {
            get { return (IMyInterface<Bar>)myInterfaces[typeof(Bar)]; }
            set { myInterfaces[typeof(Bar)] = value; }
        }
        public IMyInterface<T> Interfaces<T>() {
            return (IMyInterface<T>)myInterfaces[typeof(T)];
        }
    }
