    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myInventory = new Inventory();
                
                var i1 = new Item{name = "iPod", cost = 200,duration = 9};
                var i2 = new Item{name = "Samsung",cost = 700,duration = 5};
                var i3 = new Item{name = "Nokia", cost = 100, duration = 17};
                var i4 = new Item{name = "Motorolla",cost = 50, duration = 50};
    
                myInventory.InventoryItems.Add(i1);
                myInventory.InventoryItems.Add(i2);
                myInventory.InventoryItems.Add(i3);
                myInventory.InventoryItems.Add(i4);
                foreach (var inventoryItem in myInventory.InventoryItems)
                {
                    lstProduct.Items.Add(inventoryItem)
                }
            }
        }
    }
    
    
    
    public class Item
    {
        public string name { get; set; }
        public int duration { get; set; }
        public int cost { get; set; }
        
    }
    
    class Inventory
    {
        public List<Item> InventoryItems { get; set; }
    }
