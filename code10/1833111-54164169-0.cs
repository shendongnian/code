c#
public interface IHasHealth
{
    int hp { get; set; }
}
public class A{}
public class B : A, IHasHealth
{
    public int hp=5;
}
public class C : A, IHasHealth
{
    public int hp=10;
}
List<IHasHealth> d = new List();
d.Add(new B());
d.Add(new C());
foreach(IHasHealth a in d){
    a.hp--;
}
