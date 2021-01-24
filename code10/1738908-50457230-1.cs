    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly YourContext _context;
    
        public ItemsController(YourContext context)
        {
           _context = context;
        }
    
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Item item)
        {
            context.Items.Add(item);
            await context.SaveChangesAsync();
            return Ok(item.Id);
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            context.Items.Remove(item);
            await context.SaveChangesAsync();
            return Ok();
        }
    
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
