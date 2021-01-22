delegate void ActByRef&lt;T1,T2&gt;(ref T1 p1, ref T2 p2);
interface IActOnMe&lt;TT&gt; {ActOnMe&lt;T&gt;(ActByRef&lt;TT,T&gt; proc, ref T param);}
struct SuperThing : IActOnMe&lt;SuperThing&gt;
{
  int this;
  int that;
  ...
  void ActOnMe&lt;T&gt;(ActByRef&lt;SuperThing,T&gt;, ref T param)
  {
    proc(ref this, ref param);
  }
}
