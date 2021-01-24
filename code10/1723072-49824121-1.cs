    public class FilterCollection : Queue<IFilter>
    {
        public void Apply(ref Mat buffer)
        {
            while (Count > 0)
                Dequeue().Apply(ref buffer);
        }
    }
    public interface IFilter
    {
        void Apply(ref Mat buffer);
    }
