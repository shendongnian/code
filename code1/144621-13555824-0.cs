Ninject
Download it Extensions Contribute Visit the Dojo Speak up Sponsors Merchandise
 
Version:  
»Ninject
»MVC3
Multi injectionEdit PagePage History
Ninject allows you to inject multiple objects bound to a particular type or interface. For example, if we have our IWeapon interface, and two implementations, Sword and Dagger:
public interface IWeapon
{
    string Hit(string target);
}
public class Sword : IWeapon 
{
    public string Hit(string target) 
    {
        return "Slice " + target + " in half";
    }
}
public class Dagger : IWeapon 
{
    public string Hit(string target) 
    {
        return "Stab " + target + " to death";
    }
}
Here we have the Samurai class. You can see that its constructor takes an array of IWeapon.
public class Samurai 
{
    readonly IEnumerable<IWeapon> allWeapons;
    public Samurai(IWeapon[] allWeapons) 
    {
        this.allWeapons = allWeapons;
    }
    public void Attack(string target) 
    {
        foreach (IWeapon weapon in this.allWeapons)
            Console.WriteLine(weapon.Hit(target));
    }
}
We can create bindings from the IWeapon interface to the Sword and Dagger types.
class TestModule : Ninject.Modules.NinjectModule
{
    public override void Load()
    {
        Bind<IWeapon>().To<Sword>();
        Bind<IWeapon>().To<Dagger>();
    }
}
Finally, a kernel is created with the module we defined above. We ask Ninject for an instance of a Samurai. Now, when you ask the Samurai to attack, you will see it has been given an array of all the types bound to IWeapon.
class Program
{
    public static void Main() 
    {
        Ninject.IKernel kernel = new StandardKernel(new TestModule());
        
        var samurai = kernel.Get<Samurai>();
        samurai.Attack("your enemy");
    }
}
And you’ll see:
Stab your enemy to death
Slice your enemy in half
The kernel also exposes a GetAll method which lets you generate the same output by doing:
class Program
{
    public static void Main() 
    {
        Ninject.IKernel kernel = new StandardKernel(new TestModule());
        
        IEnumerable<IWeapon> weapons = kernel.GetAll<IWeapon>();
        foreach(var weapon in weapons)
            Console.WriteLine(weapon.Hit("the evildoers"));
    }
}
Continue reading: Object Scopes
Enkari
Ninject is the illegitimate brainchild of Nate Kohari. Copyright ©2007-2012 Enkari, Ltd and the Ninject project contributors.
