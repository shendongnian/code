            var text = new SortedDictionary<string, int>();
            while (true)
            {
                string material = Console.ReadLine();
                if(material == "stop")
                {
                    break;
                }
                string quantityString = Console.ReadLine();
                if (!Int32.TryParse(quantityString, out int newQuantity))
                {
                    continue;
                }
                if (text.TryGetValue(material, out int currentQuantity))
                {
                    text[material] = currentQuantity + newQuantity;
                }
                else
                {
                    text[material] = newQuantity;
                }
            }
            foreach(var item in text)
            {
                Console.WriteLine($"{item.Key} : {item.Value};");
            }
 
