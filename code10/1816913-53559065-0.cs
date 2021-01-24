    // Wrong
    items.Select((item,i)=>{
    item.position=i;
    return item;
    }).ToList();
    
    foreach(var item in items)
    Trace.WriteLine(item.position);
    
    // This seems to work
    items.Select((item,i)=>{
    var result = new Item{position=i};
    return result;
    }).ToList();
    
    foreach(var item in items)
    Trace.WriteLine(item.position);
 
