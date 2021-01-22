    for (int i1 = 0; i1 < collidables.Count; i1++)
    {
        //By setting i2 = i1 + 1 you ensure an obj isn't checking collision with itself, and that objects already checked against i1 aren't checked again. For instance, collidables[4] doesn't need to check against collidables[0] again since this was checked earlier.
        for (int i2 = i1 + 1; i2 < collidables.Count; i2++)
        {
            //Check collisions here
        }
    }
