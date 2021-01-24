    public class FloatListComparer : EqualityComparer<List<float>>
    {
        public override bool Equals(List<float> list1, List<float> list2)
        {
            return Enumerable.SequenceEqual(list1.OrderBy(t => t), list2.OrderBy(t => t));
        }
    
    
        public override int GetHashCode(List<float> s)
        {
            return base.GetHashCode();
        }
    }
