    class Wrapper {
        bool TryGet<T> (out T wrappedObj) {
            if (typeof(T) == ClassA.GetType()) {
                wrappedObj = objA;
            }
            //...
            return wrappedObj != null;
        }
        // or
        bool TryGet<T>(Func<U> propGetter, out U prop) {
            if (TryGet<T>(out T wrappedObj)) {
                prop = propGetter(wrappedObj);
                return true;
            }
            prop = default(U); 
            return false;
        }
    }
    if (wrapper.TryGet<ClassA>(out ClassA obj)) {
    //...
    }
    //or
    if (wrapper.TryGet<ClassA, String>(aObj =>  aObj?.SomeProperty, out String prop) {
    }
