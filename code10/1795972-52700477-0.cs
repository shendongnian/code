     public static void spawnEnemies()
            {
             
             int enemiesRemainingAlive = 0;
             double afterWavePrepTime = 5.0;
           
             bool isWaveFinished = false;
             bool startNewWave = false;
             int currentWaveNumber;
            
                Random x = new Random();
                 currentWaveNumber = x.Next(1, 7);
                for (int enemiesRemainingToSpawn = currentWaveNumber; enemiesRemainingToSpawn > 0; enemiesRemainingToSpawn--, enemiesRemainingAlive++)
                {
                    Console.WriteLine("enemies spawning" + enemiesRemainingToSpawn);
                        Console.WriteLine("enemies alive" + enemiesRemainingAlive);
                }
                Console.ReadLine();
               
            }
            //out put
            // enemies spawning2
            //enemies alive0
            //enemies spawning1
            //enemies alive1
