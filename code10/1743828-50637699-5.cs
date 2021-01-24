    public class FloatListComparer : EqualityComparer<List<float>>
    {
        public override bool Equals(List<float> list1, List<float> list2)
        {
            return list1.SequenceEqual(list2);
        }
    
    
        public override int GetHashCode(List<float> s)
        {
            return base.GetHashCode();
        }
    }
