    [HttpPost, Route("{id:int}")]
    public async Task<IActionResult> Post(int id, MenuViewModel menu){
        if (!ModelState.IsValid)
            return BadRequest("Something is wrong with the model");
    var restaurant = await db.Restaurants.Where(r => r.Id == id).Include(r=> r.Menus).FirstOrDefaultAsync();
    if (restaurant == null)
        return BadRequest("That restaurant does not exist");
    var menuModel = Mapper.Map<Menu>(menu);
    restaurant.Menus.Add(menuModel);
    db.Menus.Add(menuModel); //Add to DBContext
    db.Restaurants.Update(restaurant);
    await db.SaveChangesAsync();
    return Ok(Mapper.Map<MenuViewModel>(menuModel));
}
