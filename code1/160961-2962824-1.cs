    /* Remove ref on dictionary, you're not setting myArray to something else */
    static void addToInventory(Dictionary<string, baseItem> myArray, baseItem item, float maxAmount, ref float currentAmount)  
    {  
        if (currentAmount + item.getWeight() <= maxAmount)  
        {  
            Console.WriteLine("item.Quantity = {0}", item.Quantity);  
            if (myArray[item.Name] == null)
                Console.WriteLine("Adding new item ({0})", item.Name); 
            else
                Console.WriteLine("Item ({0}) already exists", item.Name); 
            
            myArray[item.Name] = myArray[item.Name] ?? item;
            myArray[item.Name].Quantity += item.Quantity;
            currentAmount += item.getWeight();  
        }  
        else  
        {  
            Console.WriteLine("Inventory full");  
        }
    }  
