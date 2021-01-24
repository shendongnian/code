csharp
public static bool TryGetValue<T>(this Option<T> option, [NotNullWhen(true)] out T? value)
{
    if (option is Some<T> some)
    {
        value = some.Value;
        return true;
    }
    value = default;
    return false;
}
Usage:
csharp
if(option.TryGetValue(out var value))
{
    value.SomeMethod(); // no warning - value is known to be non-null here
}
value.SomeMethod(); // warning - value may be null here.
The attribute is not available pre .Net standard 2.1/.new core 3.0, but you can manually define it yourself if it's not available:
csharp
namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>Specifies that when a method returns <see cref="ReturnValue"/>, the parameter will not be null even if the corresponding type allows it.</summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class NotNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition.</summary>
        /// <param name="returnValue">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;
 
        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }
    }
}
