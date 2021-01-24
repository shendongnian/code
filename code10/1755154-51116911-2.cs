    for(var i = 0; i < 100; i++)
    {
        Items.Add(new ItemVm
        {
            Alias = string.Format("Item {0}", i.ToString()),
            Description = string.Format("Description {0}", i.ToString()),
            Name = string.Format("Name {0}", i.ToString()),
            Value = string.Format("Value {0}", i.ToString())
        });
        Items[i].UpdateState();
    }
