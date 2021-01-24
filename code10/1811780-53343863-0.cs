        while ((line = f2.ReadLine()) != null)
        {
            string[] currentLine2 = line.Split('|');
            updateID = currentLine2[0];
            numUpdate = Convert.ToInt32(currentLine2[1]);
            
            var inventoryNode = Inventory.Where(i=>i.ID == updateID).FirstOrDefault();
            if(inventoryNode != null)
            {
                inventoryNode.Number += numUpdate;
            }
        }
