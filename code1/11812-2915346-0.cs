What if you have a generic class that has methods that could be made ambiguous depending on the type arguments? I ran into this situation recently writing a two-way dictionary. I wanted to write symmetric Get() methods that would return the opposite of whatever argument was passed. Something like this:
class TwoWayRelationship&lt;T1, T2&gt;
{
    public T2 Get(T1 key) { /* ... */ }
    public T1 Get(T2 key) { /* ... */ }
}
All is well good if you make an instance where T1 and T2 are different types:
var r1 = new TwoWayRelationship&lt;int, string&gt;();
r1.Get(1);
r1.Get("a");
But if T1 and T2 are the same (and probably if one was a subclass of another), it's a compiler error:
var r2 = new TwoWayRelationship&lt;int, int&gt;();
r2.Get(1);  // "The call is ambiguous..."
