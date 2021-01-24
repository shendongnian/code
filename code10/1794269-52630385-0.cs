    public abstract class Metadata
    {
    }
    public class Metadata<T> : Metadata
    {
        public List<T> MyCollection { set; get; }
    }
    public class MetaDataCollection
    {
        public void DoSomeThing()
        {
            List<Metadata> metadataObjects = new List<Metadata>
        {
            new Metadata<int>() { MyCollection = new List<int>()},
            new Metadata<bool>() { MyCollection = new List<bool>()},
            new Metadata<double>() { MyCollection = new List<double>()},
        };
            foreach (var item in metadataObjects)
            {
                if (item is Metadata<int>)
                {
                    var intItem = item as Metadata<int>;
                    intItem.Add(10);
                }
            }
        }
    }
