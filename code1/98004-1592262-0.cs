class ConcreteFooCtl : FooCtl&lt;FooNodeType&gt;
{
}
class FooCtl&lt;T&gt; : Panel where T : Control, IFooNode , new()
{
}
