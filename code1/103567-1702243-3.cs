    void YourMethod(IEnumerable<ICommonToBothTypes> sequence)
    {
        foreach (var item in sequence)
        {
            Console.WriteLine(item.ID);
        }
    }
    // ...
    public interface ICommonToBothTypes
    {
        long ID { get; }
    }
    public class FirstType : ICommonToBothTypes
    {
        public long ID
        {
            get { return long.MaxValue; }
        }
    }
    public class SecondType : ICommonToBothTypes
    {
        // the real Int32 ID
        public int ID
        {
            get { return int.MaxValue; }
        }
        // explicit interface implementation to expose ID as an Int64
        long ICommonToBothTypes.ID
        {
            get { return (long)ID; }
        }
    }
