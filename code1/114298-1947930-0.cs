    public class MonkeyData
    {
       public string Name { get; set; }
       public List<Food> FavoriteFood { get; set; }
    }
    public interface IMonkeyRepository
    {
       Monkey GetMonkey(string name) // fetches DTO, uses entity constructor
       void SaveMonkey(Monkey monkey) // uses entity GetData(), stores DTO
    }
    public class Monkey
    {
       private readonly MonkeyData monkeyData;
       public Monkey(MonkeyData monkeyData)
       {
          this.monkeyData = monkeyData;
       }
       public Name { get { return this.monkeyData.Name; } }
       public bool IsYummy(Food food)
       {
          return this.monkeyData.FavoriteFood.Contains(food);
       }
       public MonkeyData GetData()
       {
          // CLONE the DTO here to avoid giving write access to the
          // entity innards without business rule enforcement
          return CloneData(this.monkeyData);
       }
    }
    
