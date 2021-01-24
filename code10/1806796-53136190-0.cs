    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    
    namespace ConsoleApp18
    {
        class Program
        {
            static void Main(string[] args)
            {
                int worldSizeX = 100;
                int worldSizeY = 100;
    
                int[,] world = new int[worldSizeX * worldSizeY, 2];
    
                System.Random random = new System.Random();
    
                for (int x = 0; x < worldSizeX; x++)
                {
                    for (int y = 0; y < 2; y++)
                    {
    
                        int itemID = random.Next(0, 2); // edit range 0,2
                        world[x, y] = itemID;
                    }
                }
    
    
                string json = JsonConvert.SerializeObject(world, Formatting.Indented);
                string[,] deserialized = JsonConvert.DeserializeObject<string[,]>(json);
    
                //use "deserialized"
    
            }
    
    
    
        }
    
    }
