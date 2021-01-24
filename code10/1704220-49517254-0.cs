    public partial class ItemsInput
    {
        public int id { get; set; }
        public string name { get; set; }
        public string extraProperty{ get; set; }
     }
     
     public async Task<IHttpActionResult> Post(ItemsInput itemsInput)
        {
            // This shouldn't be triggered anymore unles it's a valid error
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Do some stuff with extraProperty here
            
            
            Items items = new Items();
            items.name = itemsInput.name;
            db.Items.Add(items);
            await db.SaveChangesAsync();
            return Created(items);
        }
