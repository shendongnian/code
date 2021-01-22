public struct PizzaDefinition
{
    public readonly string Tag; 
    public readonly string Name;
    public readonly string Description;
    public PizzaDefinition(string tag, string name, string description)
    {
        Tag = tag; Name = name; Description = description;
    }
}
public abstract class PizzaFactory
{
    public abstract IEnumerable&lt;PizzaDefinition> GetMenu();
    public abstract IPizza CreatePizza(PizzaDefinition pizzaDefinition);
}
public class ItalianPizzaFactory : PizzaFactory
{
    public enum PizzaType
    {
        HamMushroom,
        Deluxe,
        Hawaiian
    }    
    public override IEnumerable&lt;PizzaDefinition> GetMenu()
    {
        return new PizzaDefinition[] {
            new PizzaDefinition("hm:mushroom1,cheese3", "Ham&Mushroom 1", "blabla"),
            new PizzaDefinition("hm:mushroom2,cheese1", "Ham&Mushroom 2", "blabla"),
            new PizzaDefinition("dx", "Deluxe", "blabla"),
            new PizzaDefinition("Hawaian:shrimps,caramel", "Hawaian", "blabla")
        };
    }
    private PizzaType ParseTag(string tag, out object[] options){...}
    
    public override IPizza CreatePizza(PizzaDefinition pizzaDefinition)
    {
        object[] options;
        switch (ParseTag(pizzaDefinition.Tag, out options))
        {
            case PizzaType.HamMushroom:
                return new HamAndMushroomPizza(options);
            case PizzaType.Hawaiian:
                return new HawaiianPizza();
            default:
                throw new ArgumentException("The pizza" + pizzaDefinition.Name + " is not on the menu.");
        }
    }
}
