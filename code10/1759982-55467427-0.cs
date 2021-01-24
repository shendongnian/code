csharp
using System;
using Xunit;
public ref struct RefStruct1
{
    public void MethodThatThrows(int x) => throw new NotImplementedException();
}
public class Test1
{
    [Theory]
    [InlineData(0)]
    [InlineData(int.MaxValue)]
    public void MethodThatThrows_Always_ThrowsNotImplementedException(int x)
    {
        var refStruct1 = new RefStruct1();
        AssertThrows<NotImplementedException>(ref refStruct1, (ref RefStruct1 rs1) => rs1.MethodThatThrows(x));
    }
    private delegate void RefStruct1Action(ref RefStruct1 rs1);
    [System.Diagnostics.DebuggerHidden]
    private static T AssertThrows<T>(ref RefStruct1 rs1, RefStruct1Action action)
        where T : Exception
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));
        try
        {
            action(ref rs1);
            throw new Xunit.Sdk.ThrowsException(typeof(T));
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(T))
                return (T)ex;
            throw new Xunit.Sdk.ThrowsException(typeof(T), ex);
        }
    }
}
