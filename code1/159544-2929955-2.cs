    public static TResult SafeGet<T, TResult>(this T obj, Func<T, TResult> selector) {
        if (obj == null) { return default(TResult); }
        else { return selector(obj); }
    }
    
    var myClass = new MyClass();
    var result = myClass.SafeGet(x=>x.SomeProp);
