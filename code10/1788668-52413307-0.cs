        public bool RunActionIf(Item item, Shape shape, Color color, Material material, Action action)
        {
            if(item.ItemShape == shape && item.ItemColor == color && item.ItemMaterial == material)
            {
                action();
                return true;
            }
            return false;
        }
        public void RunAction(Item item)
        {
            var result =
                RunActionIf(item, Shape.square, Color.blue, Material.glass, Action1) ||
                RunActionIf(item, Shape.square, Color.blue, Material.wood, Action2) ||
                /* Implement your whole table like this */;
            if(!result)
            {
                Console.WriteLine("No matching action found");
            }
        }
