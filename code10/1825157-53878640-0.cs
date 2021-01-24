            public static void EquipWeapon(string weapon_name)
            {
                Weapon weapon_to_equip = new Weapon("Test Weapon", 0, 0);
                bool WeaponExists()
                {
                    foreach (Weapon weapon in Weapon.weapon_list)
                    {
                        if (weapon.name == weapon_name)
                        {
                            weapon_to_equip = weapon;
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    return false;
                }
                if (WeaponExists())
                {
                    Console.WriteLine("Stats:");
                    Weapon.CompareWeaponStats(weapon_to_equip, Player.equipped_weapon);
                    Console.WriteLine("Are you sure you want to equip this weapon?");
                    if (QuestionPrompt() == true)
                    {
                        Console.WriteLine("You equipped the weapon!");
                        ChangeWeapon(weapon_to_equip);
                    }
                    else
                    {
                        Console.WriteLine("You will continue with the same weapon, the new one was discarded.");
                    }
                }
                else
                {
                    Console.WriteLine("The weapon you want to equip doesn't exist!");
                }
            }
