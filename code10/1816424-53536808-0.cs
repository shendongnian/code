        int i = 0;
        bool saved = true; 
        foreach (var item in records)
        {
             item.Property += 10;
    
             if (i % 5 == 0 && i != 0)
             {
                 ctx.SaveChanges();
                 saved = true; 
             }
             else 
             {
                 saved = false; 
             }
             i++;
        }
    
        if (!saved) // if there are any unsaved items then save it here
        {
             ctx.SaveChanges();
        }
