    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>() {
                    new Item() { name = "a",  number = 1 },
                    new Item() { name = "b",  number = 2 },
                    new Item() { name = "c",  number = 3 },
                    new Item() { name = "d",  number = 4 },
                    new Item() { name = "e",  number = 5 },
                    new Item() { name = "f",  number = 6 },
                    new Item() { name = "g",  number = 7 },
                    new Item() { name = "h",  number = 8 },
                    new Item() { name = "i",  number = 9 },
                    new Item() { name = "j",  number = 10 },
                };
                Random rand = new Random();
                List<Item> randLetters = items.Select((x, i) => new { x = x, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.x).ToList();
                List<Item> randNumbers = items.Select((x, i) => new { x = x, rand = rand.Next() }).OrderBy(x => x.rand).Select(x => x.x).ToList();
                //delete random pairs
                for (int i = randLetters.Count - 1; i >= 0; i--)
                {
                    //find matching item in randNumbers
                    randNumbers = randNumbers.Where(x => x.name != randLetters[i].name).ToList();
                    randLetters.RemoveAt(i);
                }
            }
        }
        public class Item
        {
            public string name { get; set; }
            public int number { get; set; }
        }
    }
