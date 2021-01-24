    public class MyController : Controller 
    {
        private readonly MdsEntityCRUD mdsCrud;
        public MyController(IMemoryCache memoryCache) 
        {
            ServiceClient client = ...;
            mdsCrud = new MdsEntityCRUD(memoryCache, client, "modelname", "entityName", "v1");
        }
    }
