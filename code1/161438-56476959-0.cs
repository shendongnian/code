 lang-cs
public static class ExceptionExtensions
{
    [DebuggerHidden]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Throw(this Exception exception) => throw exception;
}
and then we can use it...
using static SomeNamespace.ExceptionExtensions;
public class SomeClass
{
    private void SomeMethod(string value)
    {
        var exception = GetArgumentException(nameof(value), value);
        exception?.Throw(); // only throw if any exception was getted
        
        ... //method implementation
    }
    
    private Exception GetArgumentException(string paramName, string value)
    {
        if (value == null)
            return new ArgumentNullException(paramName);
        if (string.IsNullOrEmpty(value))
            return new ArgumentException("value is empty.", paramName);
        return null;
    }
}
**With that the `Throw()` method will not appear in the stack trace.**
