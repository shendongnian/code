    string[] itemProperties = item.Split(new string[] { "-" });
    itemProperties = itemProperties.Select(p => p.Trim());
    Item item = new Item()
    {
      Number = itemProperties[0],
      Name = itemProperties[1],
      Description = itemProperties[2]
    }
