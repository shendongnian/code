    class StockEntry
    {
      public IEnumerable<PerLocationStock> Stocks { get; set; }
    }
    
    class PerLocationStock
    {
      public string LocationId { get; set; }
      public IEnumerable<Fruit> Fruits { get; set; }
    }
    
    public class Fruit
    {
      public string TypeId { get; }
      public Fruit(string typeId)
      {
          TypeId = typeId;
      }
      protected bool Equals(Fruit other) => string.Equals(TypeId, other.TypeId);
      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((Fruit) obj);
      }
      public override int GetHashCode() => (TypeId != null ? TypeId.GetHashCode() : 0);
    }
