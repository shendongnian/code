csharp
private Func<S,T> AutoMapFactory<S,T>() where T: class, new() where S : class
        {
            List<Action<T, S>> mapActions = typeof(T).GetProperties().Where(tp => tp.CanWrite)
                .SelectMany(tp => typeof(S).GetProperties().Where(sp => sp.CanRead)
                .Where(sp => sp.Name == tp.Name && tp.PropertyType.IsAssignableFrom(sp.PropertyType))
                .Select(sp => (Action<T,S>)((targetObj, sourceObj) => 
                    tp.SetValue(targetObj, sp.GetValue(sourceObj)))))
                .ToList();
            return sourceObj => {
                if (sourceObj == null) return null;
                T targetObj = new T();
                mapActions.ForEach(action => action(targetObj, sourceObj));
                return targetObj;
            };
        }
How to use this:
csharp
...
var autoMapper = AutoMapFactory<SourceType, TargetType>(); //Get Only 1 instance of the mapping function
...
someCollection.Select(item => autoMapper(item)); //Almost instantaneous
...
