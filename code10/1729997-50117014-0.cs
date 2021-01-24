    public void RegisterIfObservable<T>(T value){
        Type type = value.GetType(); 
        // I don't think you can simply use typeof(T) instead of value.GetType() here
        // if the compiler does not know for certain at compile time 
        // whether T will be an IObservable. 
        // And if you DO know that at compile time, then use the alternative solution below.
        if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
        {
            Type genericArgument = type.GetGenericArguments()[0];
            MethodInfo method = this.GetType().GetMethod("RegisterObservable"); 
            // instead of this.GetType() you could use the type
            // of a helper class where RegisterObservable is located
            MethodInfo genericMethod = method.MakeGenericMethod(genericArgument);
            genericMethod.Invoke(this, new object[]{value});
        }
    }
