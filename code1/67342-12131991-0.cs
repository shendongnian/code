public delegate void ActByRef&lt;T1,T2&gt;(ref T1 p1);
public delegate void ActByRefRef&lt;T1,T2&gt;(ref T1 p1, ref T2 p2);
public interface IReadWriteActUpon&lt;T&gt;
{
  T Value {get; set;}
  void ActUpon(ActByRef&lt;T&gt; proc);
  void ActUpon&lt;TExtraParam&gt;(ActByRefRef&lt;T, TExtraParam&gt; proc, 
                           ref TExtraparam ExtraParam);
}
public sealed class MutableWrapper&lt;T&gt; : IReadWrite&lt;T&gt;
{
  public T Value;
  public MutableWrapper(T value) { this.Value = value; }
  T IReadWriteActUpon&lt;T&gt;.Value {get {return this.Value;} set {this.Value = value;} }
  public void ActUpon(ActByRef&lt;T&gt; proc)
  {
    proc(ref Value);
  }
  public void ActUpon&lt;TExtraParam&gt;(ActByRefRef&lt;T, TExtraParam&gt; proc, 
                           ref TExtraparam ExtraParam)
  {
    proc(ref Value, ref ExtraParam);
  }
}
