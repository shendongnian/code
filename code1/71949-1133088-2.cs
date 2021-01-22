    var props = e.Item.DataItem.GetType().GetFields();
    
    foreach (var item in props)
    {
        Console.WriteLine(string.Format("{0}:{1}", item.Name, DataBinder.Eval(e.Item.DataItem, item.Name)));
    }
