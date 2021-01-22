    public class WeightedRandomization
    {
        public static IWeightedObject Choose(List<IWeightedObject> list, Random rand)
        {
            int totalweight = list.Sum(c => c.Weight);
            int choice = rand.Next(totalweight);
            int sum = 0;
            foreach (IWeightedObject obj in list)
            {
                for (int i = sum; i < obj.Weight + sum; i++)
                {
                    if (i >= choice)
                    {
                        return obj;
                    }
                }
                sum += obj.Weight;
            }
            return null;
        }
    }
    public interface IWeightedObject
    {
        int Weight { get; }
    }
