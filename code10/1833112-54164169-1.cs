c#
public interface IHasHealth
{
    int hp { get; set; }
}
public class A{}
public class B : A, IHasHealth
{
    public int hp { get; set; } = 5;
}
public class C : A, IHasHealth
{
    public int hp { get; set; } = 10;
}
public void Main(){
    List<IHasHealth> d = new List<IHasHealth>();
    d.Add(new B());
    d.Add(new C());
    foreach(IHasHealth a in d){
        a.hp--;
    }
}
