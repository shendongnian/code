    List<Item> inventory = new List<Item>();
    // Fill inventory with items of different type.
    
    List<Weapon> weapons = (IEnumerable<Weapon>)(inventory.Where(item => item.GetType() == typeof(Weapon))).ToList();
    List<Projectile> weapons = (IEnumerable<Weapon>)(inventory.Where(item => item.GetType() == typeof(Projectile))).ToList();
