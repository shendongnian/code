    public class WeightedRandomization
    {
        public static IWeighted Choose(List<IWeighted> list, Random rand)
        {
            int totalweight = list.Sum(c => c.Weight);
            int choice = rand.Next(totalweight);
            int sum = 0;
            foreach (IWeighted obj in list)
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
    public interface IWeighted
    {
        int Weight { get; set; }
    }
