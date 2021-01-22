    public interface IFoo
    {
        IEnumerable<int> GetItems( int[] box );
        ...
    }
    public class Bar : IFoo
    {
        public IEnumerable<int> GetItems( int[] box )
        {
            int value = box[0];
            // use and change value and yield to your heart's content
            box[0] = value;
        }
    }
