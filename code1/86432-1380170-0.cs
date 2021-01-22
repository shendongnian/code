abstract class Fruit
{
    public Fruit()
    {
        Initialize();
    }
    protected virtual void Initialize()
    {
        Console.WriteLine("Fruit.Initialize");
    }
}
class Apple : Fruit
{
    public Apple()
        : base()
    { }
    protected override void Initialize()
    {
        base.Initialize();
        Console.WriteLine("Apple.Initialize");
    }
    public override string ToString()
    {
        return "Apple";
    }
}
class Orange : Fruit
{
    public Orange()
        : base()
    { }
    protected override void Initialize()
    {
        base.Initialize();
        Console.WriteLine("Orange.Initialize");
    }
    public override string ToString()
    {
        return "Orange";
    }
}
class FruitFactory
{
    public static T CreateFruit&lt;T>() where T : Fruit, new()
    {
        return new T();
    }
}
public class Program
{
    static void Main()
    {
        Apple apple = FruitFactory.CreateFruit&lt;Apple>();
        Console.WriteLine(apple.ToString());
        Orange orange = new Orange();
        Console.WriteLine(orange.ToString());
        Fruit appleFruit = FruitFactory.CreateFruit&lt;Apple>();
        Console.WriteLine(appleFruit.ToString());
    }
}
