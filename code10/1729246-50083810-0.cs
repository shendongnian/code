            List<Enemy> Enemies = new List<Enemy>();// Declare your list
            // Loop To populate the list 
            for (int i = 1; i <= eNumber; i++)
            {
              Enemies.Add(new Enemy($"Goblin{i}", rndm.Next(6, 12), rndm.Next(6, 12), rndm.Next(6, 12)));
            }
            // Loop Throught The Enemies, Then you can access their status 
            for (int i = 0; i < Enemies.Count; i++)
			{
                Console.WriteLine(Enemies[i].EName,Enemies[i].EHealth,Enemies[i].EStamina,Enemies[i].EPower);
			}
