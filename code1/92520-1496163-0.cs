    interface IHasParent<T>
    {
         T Parent { get; set; }
    }
    public class SpecificObject : IHasParent<SpecificObject>
    {
        public SpecificObject Parent { get; set; }
    }
