    public async Task<IActionResult> saveData(List<ItemAttribute> data)
    {
            foreach(var item in data)
            {
              _context.ItemAttribute.Add(item);
            }
            await _context.SaveChangesAsync();
    }
