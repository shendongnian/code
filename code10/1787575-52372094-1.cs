    IPistol pistol;  
   
    Console.WriteLine("Please, choose your weapon. \n1: Glock 18 \n2:");
                switch (choice)
                {
                    case 1:
                        pistol = new Glock18() ;
                        break;
                    case 2:
                        pistol = new WaltherP99() ;
                        break;
                    default:
                        pistol = new BasicGun() ;
                        break;
                }
        
        
                Console.WriteLine("Let's shoot. Press space to fire and 'r' to reload. ('q' to quit) \n");
        
                while (true)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (char.IsWhiteSpace(input.KeyChar))
                    {
                        pistol.Shoot();
                    }
