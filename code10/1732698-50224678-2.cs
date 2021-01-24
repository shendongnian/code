    List<Item> inventory = new List<Item>();
    // Fill inventory with items of different type.
    
    List<Weapon> weapons = inventory.Where(item => item.GetType() == typeof(Weapon)).Cast<Weapon>().ToList();
    List<Projectile> weapons = inventory.Where(item => item.GetType() == typeof(Projectile)).Cast<Projectile>().ToList();
