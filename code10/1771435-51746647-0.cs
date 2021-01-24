    public class Obj
    {
        private bool InnerProperty { get; set; } = false;
    
        public static int CountInner(IEnumerable<Obj> list)
        {
            return list.Count(b => b.InnerProperty);
        }
    }
