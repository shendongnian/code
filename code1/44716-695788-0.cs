    public static class Group
    {
        public static DescribedInt A = new DescribedInt(12, "some description");
        public static DescribedInt B = new DescribedInt(88, "another description");
    }
    public class DescribedInt
    {
        public readonly int data;
        public readonly string Description;
    
        public DescribedInt(int data, string description)
        {
            this.data = data;
            this.Description = description;
        }
        
        //automatic cast to int
        public static implicit operator int(DescribedInt orig)
        {
            return orig.data;
        }
    
        //public DescribedInt(string description)
        //{
        //    this.description = description;
        //}
     
        //if you ever need to go the "other way"
        //public static implicit operator DescribedInt(int orig)
        //{
        //    return new DescribedInt(orig, "");
        //}
    }
