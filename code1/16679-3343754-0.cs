public class MyClass
{
    private Dictionary&lt;string, int&gt; _myCollection = new Dictionary&lt;string, int&gt;() { { "A", 1 }, { "B", 2 }, { "C", 3 } };
    public IEnumerable&lt;KeyValuePair&lt;string,int&gt;&gt; MyCollection
    {
        get { return _myCollection.AsEnumerable&lt;KeyValuePair&lt;string, int&gt;&gt;(); }
    }
}
