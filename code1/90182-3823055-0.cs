    public class Pair<TSource, TResult> :
    #if DOTNET4
        Tuple<TSource, TResult>
    #else
        KeyValuePair<TSource, TResult>
    #endif
    {
    }
    
    public Pair<TSource, TResult> SomeMethod<TSource, TResult>(){...}
