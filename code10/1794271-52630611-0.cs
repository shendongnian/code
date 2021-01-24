    //use interfaces instead of abstract class
    public interface IMetadata
    {
        public List<object> MyCollection { get; set; }
    }
    
    public interface IMetadata<T>
    {
        public List<T> MyCollection { get; set; }
    }
    
    //as List<> the List and List<> don't derive from each other but instead have a common interface the ungeneric IList
    public class Metadata : IMetadata
    {
        public List<object> MyCollection { get; set; }
    }
    
    //implement the generic and ungeneric interface
    public class Metadata<T> : IMetadata<T>, IMetadata
    {
        public List<T> MyCollection { get; set; }
        //hide the ungeneric interface member MyCollection
        List<object> IMetadata.MyCollection { get { return this.MyCollection.Cast<object>().ToList(); } set { this.MyCollection = value.Cast<object>().ToList(); } }
    
    }
    
    public class MetaDataCollection
    {
        public void DoSomeThing()
        {
            //make a list of IMetadata
            List<IMetadata> metadataObjects = new List<IMetadata>
            {
                new Metadata<int>() { MyCollection = new List<int>()},
                new Metadata<bool>() { MyCollection = new List<bool>()},
                new Metadata<double>() { MyCollection = new List<double>()},
            };
    
            foreach (var item in metadataObjects)
            {
                //item.MyCollection is now a List<object>
            }
        }
    }
