static class FooInvoker&lt;T&gt;
{
  public Action&lt;Foo&gt; theAction = configureAction;
  void ActionForOneKindOfThing&lt;TT&gt;(TT param) where TT:thatKindOfThing,T
  {
    ...
  }
  void ActionForAnotherKindOfThing&lt;TT&gt;(TT param) where TT:thatOtherKindOfThing,T
  {
    ...
  }
  void configureAction(T param)
  {
    ... Determine which kind of thing T is, and set `theAction` to one of the
    ... above methods.  Then end with ...
    theAction(param);
  }
}
