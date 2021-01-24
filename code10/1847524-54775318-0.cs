    public interface IDataSub {
        bool MatchesType(Type t);
        object GetValue();
    }
    public class DataSub<T> : IDataSub {
        private T _cache;
        public T Value {
            get { return _cache; }
            set { _cache = value; }
        }
        public bool MatchesType(Type t) {
            return typeof(T) == t; // or something similar, in order to handle inheritance
        }
        public object GetValue() {
            return Value;
        }
    }
    public class Client {
        Dictionary<Type, IDataSub> data = new Dictionary<Type, IDataSub>() ;
        public void AddData<T>(T someValueOfTypeT) {
            data.Add(typeof(T), new DataSub<T> { Value = someValueOfTypeT });
        }
        public void UseData() {
            foreach(var dataType in data.Keys) {
                var dataValue = data[dataType];
                ProcessDataValue(dataType, dataValue);
            }
        }
        public void ProcessDataValue(Type dataType, IDataSub dataValue)
        {
            if(dataValue.MatchesType(dataType))
                AddProcessedDataValue(dataType, dataValue.GetValue().ToString());
        }
    }
**If the usage of `DataSub.Value.ToString` is only an example, and in the _real world_ you need to access `DataSub.Value` using its type `T`**, you should apply a broader reworking of you code.
What do you think about the following approach? This is an application of the pattern I like call [set of responsibility](https://javapeanuts.blogspot.com/2018/10/set-of-responsibility.html) (I wrote the linked post about this topic), a variation of GoF's [chain of responsibility](https://en.wikipedia.org/wiki/Chain-of-responsibility_pattern):
    public interface IDataSub {
        object GetValue();
    }
    public class DataSub<T> : IDataSub {
        private T _cache;
        public T Value {
            get { return _cache; }
            set { _cache = value; }
        }
        public object GetValue() {
            return Value;
        }
    }
    public interface IDataHandler {
        bool CanHandle(Type type);
        void Handle(object data);
    }
    public class Client {
        private readonly Dictionary<Type, IDataSub> data = new Dictionary<Type, IDataSub>();
        private readonly IList<IDataHandler> handlers = new List<IDataHandler>();
        public void AddData<T>(T someValueOfTypeT) {
            data.Add(typeof(T), new DataSub<T> { Value = someValueOfTypeT });
        }
        public void RegisterHandler(IDataHandler handler) {
            handlers.Add(handler);
        }
        public void UseData() {
            foreach(var dataType in data.Keys) {
                handlers.FirstOrDefault(h => h.CanHandle(dataType))?.Handle(data[dataType].GetValue());
            }
        }
        
        // Lambda-free version
//        public void UseData() {
//            foreach(var dataType in data.Keys) {
//                for (int i = 0; i < handlers.Count; i++) {
//                    if (handlers[i].CanHandle(dataType)) {
//                        handlers[i].Handle(data[dataType].GetValue());
//                        break; // I don't like breaks very much...
//                    }
//                }
//            }
//        }
    }
    class StringDataHandler : IDataHandler {
        public bool CanHandle(Type type) {
            // Your logic to check if this handler implements logic applyable to instances of type
            return typeof(string) == type;
        }
        public void Handle(object data) {
            string value = (string) data;
            // Do something with string
        }
    }
    
    class IntDataHandler : IDataHandler {
        public bool CanHandle(Type type) {
            // Your logic to check if this handler implements logic applyable to instances of type
            return typeof(int) == type;
        }
        public void Handle(object data) {
            int value = (int) data;
            // Do something with int
        }
    }
This approach allow you to decouple data storage and data iteration logic from data-handling logic specific of different data-types: `IDataHandler`'s implementations known what type of data they can handle and cast generic `object` reference to desired type. If you prefer, you can merge `CanHandle` method into `Handle` method, remving the former method and changing `UseData` to
public void UseData() {
    foreach(var dataType in data.Keys) {
        foreach(var handler in handlers) {
            handler.Handle(dataType, data[dataType].GetValue())
        }
    }
}
and handler implementations to
class IntDataHandler : IDataHandler {
        public void Handle(Type dataType, object data) {
            if(typeof(int) == type) {
                int value = (int) data;
                // Do something with int
            }
        }
    }
This variant is slightly more type-safe, because in the first variant was already possibile to call `Handle` method without a previus call to `CanHandle`.
**If you liked this approach, you can bring it forward, simplifying your data structure and converting `data` from `IDictionary` to `IList`**:
    public interface IDataSub {
        object GetValue();
    }
    public class DataSub<T> : IDataSub {
        private T _cache;
        public T Value {
            get { return _cache; }
            set { _cache = value; }
        }
        public object GetValue() {
            return Value;
        }
    }
    public interface IDataHandler {
        bool CanHandle(object data);
        void Handle(object data);
    }
    public class Client {
        private readonly IList<IDataSub> data = new List<IDataSub>();
        private readonly IList<IDataHandler> handlers = new List<IDataHandler>();
        public void AddData<T>(T someValueOfTypeT) {
            data.Add(new DataSub<T> { Value = someValueOfTypeT });
        }
        public void RegisterHandler(IDataHandler handler) {
            handlers.Add(handler);
        }
        public void UseData() {
            foreach(var dataItem in data) {
                var value = dataItem.GetValue();
                handlers.FirstOrDefault(h => h.CanHandle(value))?.Handle(value);
            }
        }
        
        // Lambda-free version as above...
    class StringDataHandler : IDataHandler {
        public bool CanHandle(object data) {
            // Your logic to check if this handler implements logic applyable to instances of String
            return data is string;
        }
        public void Handle(object data) {
            string value = (string) data;
            // Do something with string
        }
    }
    
    class IntDataHandler : IDataHandler {
        public bool CanHandle(Type type) {
            // Your logic to check if this handler implements logic applyable to instances of int
            return type is int;
        }
        public void Handle(object data) {
            int value = (int) data;
            // Do something with int
        }
    }
The `CanHandle`-free variant can simplify `IDataHandler` interface and its implementation in this case, too...
I hope my answer can help you resolving you design scenario; I build it upon an approach I like very much, because it allows to apply subtype-specific logic to instances of different classe, given they share a common superclass (as `object` in my code samples).
