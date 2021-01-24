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
            
            //Convert the input object to json string
            var itemsInputJson = JsonConvert.SerializeObject(itemsInput);
            //Load json string to the EF Model, this will fill up all compatible
            //properties and ignore non-matching ones
            Items items = JsonConvert.DeserializeObject<Items>(itemsInputJson);
            db.Items.Add(items);
            await db.SaveChangesAsync();
            return Created(items);
        }
