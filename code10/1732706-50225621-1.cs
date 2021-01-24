    var playerInventory = new List<Item>();
	
	playerInventory.Add(new Weapon());
	playerInventory.Add(new Weapon());
	playerInventory.Add(new Weapon());
	playerInventory.Add(new Weapon());
	playerInventory.Add(new Projectile());
	playerInventory.Add(new Projectile());
	
    // player inventory should have 4 weapons
	playerInventory.IsTypeOf<Weapon>().Should().HaveCount(4);
    // player inventory should have 2 projectiles
	playerInventory.IsTypeOf<Projectile>().Should().HaveCount(2);
