public abstract class AbstractClass&lt;T&gt;
{
    public int Id { get; set; }
    public int Name { get; set; }
    public abstract List&lt;T&gt; Items { get; set; }
}
public class Container : AbstractClass&lt;Widgets&gt;
{
    public override List&lt;Widgets&gt; Items { get; set; }
}
