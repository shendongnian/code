    public class CustomComparer : IEqualityComparer<Order>
        {
            public bool Equals(Order x, Order y)
            {
                return x.FoodId == y.FoodId;
            }
    
            public int GetHashCode(Order obj)
            {
                return obj.FoodId.GetHashCode();
            }
        }
