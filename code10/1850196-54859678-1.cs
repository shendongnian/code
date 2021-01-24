var test = new Test();
test.SetValue("");
var newStrings = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
newStrings.AsParallel()
    .ForAll(newString =>
    {
        var value = test.GetValue() as string;
        value += $" {newString}";
        test.SetValue(value);
    });
// Eight, Six, Three, Four, One, Two, Five, Nine
var result = test.GetValue() as string;
If you want thread safety you need to be locking the value while your threads are changing it.
With the improved code below, you will notice that now you have all the words added, but they are still out of order.
When dealing with thread safety you really need to step back and look at the whole picture as not one place with a couple locks is going to magically make an entire class or application thread safe.
public class Test<T> where T : class
{
    private readonly object syncLock = new object();
    private T _value;
    public delegate void MyAction(ref T value);
    public void EditObject(MyAction action)
    {
        lock (syncLock)
        {
            action(ref _value);
        }
    }
    public T GetValue()
    {
        lock (syncLock)
        {
            return _value;
        }
    }
}
var test = new Test<string>();
var newStrings = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
newStrings.AsParallel()
    .ForAll(newString =>
    {
        test.EditObject((ref string o) => o += $" {newString}");
    });
// Three Four Five Six One Two Ten Nine Eight Seven
var result = test.GetValue() as string;
