    List<Device> list = csvContext.Read<Device>(streamReader, csvFileDescription).ToList();
    //Use below line of code to assign datetime to all object in list then add and save.
    list.ForEach(x=> x.UploadDateTime = DateTime.Now);
   
    db.Devices.AddRange(list);
    // code for insert Date now on my date column because it leaves blank
    db.SaveChanges();
