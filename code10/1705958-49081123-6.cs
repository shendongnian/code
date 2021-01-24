     public IActionResult Post(PostViewModel pvm)
    //objects to save in our db context
    Post post = new Post()
    
    //collection objects we will fill the list in below
    
    Tag tag = new Tag();
    Image img = new Image();
    
    //these lists will pass the value of pvm.tags List and pvm.Images List
    // To our post object
    
    List<Images> ImgHolderList = new List<Images>();
    List<Tags> TagHolderList = new List<Tags>();
    
    //bind properties from vm if pvm is valid
    if(!ModelState.IsValid){
    
    return BadRequest("error");
    }
    
    
    //... Know add image and tag objects to to our empty holder Collections
    ImgHolderList = pvm.Images;//---------> this is where I think the null was comming ftm
    TagHolderList = pvm.Tagsl
    
    //bind properties from vm if pvm is valid
    if(ImgHolderList == null || TagHolderList == null){
    
    return NoContent();
    }
    
    Post.Images = ImageHolderList;//---------> this is where I think the null was comming ftm
    Post.Tags = TagHolderList;//---------> this is where I think the null was comming ftm
    
    //---------better to use some design/mapper but for simplicity bind model here
    //...add all other properties
    
    post.primitives = pvm.Id;
    post.primitives = pvm.Lat
    
    //.......
    
    // know our object graph is full hopefully
    
       context.Posts.Add(Image1);
                   
    
                    context.SaveChanges();
    
    return Ok;
    }
    
    
    
    
    know you want to Get this collection very simple
    
    [Produces("application/json")] //with this your api controller returns json with OK()
        [Route("api/GetAll")]
        public class GetAllController : Controller
        {
        private readonly ApiContext ctx = ApiContext.db; // OR use DI
    
       // GET api/values
            [HttpGet]
            public IActionResult Get()
            {
                var x = ctx.Posts.Include(x => x.Images).Include(x => x.Tags)ToList();
                return Ok(x.ToList());
            }
