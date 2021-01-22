    IQueryable<Customers> query;
    
    Switch(filter)
    {
    
    case 1:
        query = Customers.Where(c => c.Type == "ABC");
        break;
    case 2:
        query = Customers.Where(c => c.Type == "CDE");
        break;
    }
    
    foreach(var custrow in query)
    {
        //Do Logic
    }
