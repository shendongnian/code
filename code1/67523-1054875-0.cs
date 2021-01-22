    public interface IManaged
    {
        string[] ReturnArray();
    }
    public class Managed : IManaged
    {
        public string[] ReturnArray()
        {
            return new string[] { "A", "B", "C" };
        }
    }
