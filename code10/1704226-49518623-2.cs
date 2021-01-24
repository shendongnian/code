    public class ItemDTO 
    {
         public int Id { get; set;}
         public string Name { get; set;}
         public string CustomProperty { get; set; }
    }
    public class ItemsController : ApiController
    {
        MyCustomContext _context;
        public ItemsController(MyCustomContext context)
        {
            _context = context;
        }
        public IEnumerable<ItemDTO> Get(ODataQueryOptions<Item> q)
        {
           var itemsQuery = _context.Items.AsQueryable();
           itemsQuery = q.ApplyTo(itemsQuery , new ODataQuerySettings()) as IQueryable<Item>;
           
           var mapperConfiguration = this.GetMapperConfiguration();
           return itemsQuery.ProjectTo<ItemDTO>(mapperConfiguration);
        }
        public IConfigurationProvider GetMapperConfiguration()
        {
            return new MapperConfiguration(x => x.CreateMap<Item, ItemDTO>().ForMember(m => m.CustomProperty, o => o.MapFrom(d => d.Id + "Custom")));
        }
    }
