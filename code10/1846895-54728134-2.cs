`C#
internal abstract class AutoRegisterThreadBase { }
internal class AutoRegisterThread<T> : AutoRegisterThreadBase 
   where T: AutoRegisterAbstract
{
field1....
method1...
}
`
Your main form field can now be of type `AutoRegisterThreadBase`
Note, if desired, the non-generic parent class can have the same name as the generic class; in your case, `AutoRegisterThread`. 
**EDIT**: Extended example, with usage:
`C#
internal abstract class AutoRegisterThreadBase { /* Leave empty, or put methods that don't depend on typeof(T) */ }
internal abstract class AutoRegisterAbstract { /* Can have whatever code you need */ }
internal class AutoRegisterThread<T> : AutoRegisterThreadBase
    where T : AutoRegisterAbstract
{
    private int someField;
    public void SomeMethod() { }        
}
internal class AutoRegisterWidget : AutoRegisterAbstract { /* An implementation of AutoRegisterAbstract; put any relevant code here */ }
// A type that stores an AutoRegisterThread<T> (as an AutoRegisterThreadBase)
class SomeType
{
    public AutoRegisterThreadBase MyAutoRegisterThread { get; set; }
}
// Your code that uses/calls the above types
class Program
{        
    static void Main(string[] args)
    {
        var someType = new SomeType();
        // Any sub-class of AutoRegisterThreadBase, including generic classes, is valid
        someType.MyAutoRegisterThread = new AutoRegisterThread<AutoRegisterWidget>();
        // You can then get a local reference to that type 
        // in the code that's created it - since you know the type here
        var localRefToMyAutoRegisterThread = someType.MyAutoRegisterThread as AutoRegisterThread<AutoRegisterWidget>;
        localRefToMyAutoRegisterThread.SomeMethod();
    }
}
`
