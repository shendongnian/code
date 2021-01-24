    public class Container<T> : IContainer<T>
    {
        public IEnumerable<T> SaveToCache(IEnumerable<T> models)
        {
            return models;
        }
        
        IEnumerable IContainer.SaveToCache(IEnumerable models)
        {
        }
    }
    var container = new Container<string>();
    container.SaveToCache(new string[] { "" }); // The generic method is avaiable if we have an referecne to the class
    container.SaveToCache(new int[] { 0 });// And this will be a compile time error as expected
    IContainer icontainer = container;
    icontainer.SaveToCache(new string[] { "" }); // The non genric method will be called 
    icontainer.SaveToCache(new int[] { 0 });// And this will be a runtime time error 
