    using System;
    namespace SmalltalkBooleanExtensionMethods
    {
    
    public static class IntExtension
    {
    
    public static int timesRepeat<T> (this int x, Func<T> method)
    {
    for (int i = x; i > 0; i--) {
    method.DynamicInvoke ();
    }
    return x;
    }
    
    public static int timesRepeat (this int x, Action method)
    {
    for (int i = x; i > 0; i--) {
    method.DynamicInvoke ();
    }
    return x;
    }
    
    }
    
    }
    
