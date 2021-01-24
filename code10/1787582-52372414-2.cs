    while (true)
    {
        ConsoleKeyInfo input = Console.ReadKey(true);
        if (char.IsWhiteSpace(input.KeyChar))
        {
            if (choseWeapon.HasAmmo
                chosenWeapon.Shoot();
            else
               chosenWeapon.MakeClickSound();
        }
        else if (input.KeyChar == 'r')
            chosenWeapon.Reload();
    }
