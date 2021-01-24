    public class MetaDataCollection
    {
        public void DoSomeThing()
        {
            List<Metadata> metadataObjects = new List<Metadata>
            {
                new Metadata<int>() { MyCollection = new List<int>() { 1, 2, 3, 4} },
                new Metadata<bool>() { MyCollection = new List<bool>() { true, false, false} },
                new Metadata<double>() { MyCollection = new List<double>() { 1.5, 2.1 } },
            };
    
            Dictionary<Type, Action<Metadata>> actionLookup = new Dictionary<Type, Action<Metadata>>()
            {
                { typeof(int), (meta) => Console.WriteLine(((Metadata<int>)meta).MyCollection[0]) },
                { typeof(bool), (meta) => Console.WriteLine(((Metadata<bool>)meta).MyCollection[0]) },
                { typeof(double), (meta) => Console.WriteLine(((Metadata<double>)meta).MyCollection[0]) }
            };
    
            foreach (var item in metadataObjects)
            {
                Type metaDataType = item.GetType().GenericTypeArguments.First();
                actionLookup[metaDataType](item);
            }
        }
    }
