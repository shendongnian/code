    public enum Fruit
    {
       Apple,
       Orange,
       Lemon
    }
    public interface IFruitList : IList<int>
    {
       Fruit Type { get; }
    };
    public class FruitList : List<int>, IFruitList
    {
       private readonly type;
       FruitList(Fruit type)
         : base()
       {
          this.type = type;
       }
       FruitList(Fruit type, IEnumerable<int> collection)
         : base(collection)
       {
          this.type = type;
       }
       Fruit Type { return type; }
    }
