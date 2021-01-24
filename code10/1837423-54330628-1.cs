       foreach (var route in XmlData.ROUTES)
       { 
        if(OriginalSignal.Equals(route.ENTRANCESIGNAL))
        {
        Console.WriteLine(route.ID);  
        }
       }
