    [HttpPost("{productKey}")]
    public IActionResult Create(string productKey, [FromBody] string rawData ) {
        LegacyStatViewModel item = JsonConvert.DeserializeObject<LegacyStatViewModel>(rawData);
        if(item != null){
            NewUsageViewModel aNewUsageViewModel = new NewUsageViewModel {
                Cpu = Convert.ToInt32(item.Cpu),
                BinaryVersion = (item.Version == null ? "UNKNOWN" : item.Version),                
                LastConnection = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Memory = Convert.ToInt32(item.Mem),
                ProductKey = productKey               
            };
        
            _context.AspNetNewUsages.Add(aNewUsageViewModel);
            _context.SaveChanges();
        
            return CreatedAtRoute("GetStat", new { ProductKey = aNewUsageViewModel.ProductKey }, item);
        }
        return BadRequest();
    }
