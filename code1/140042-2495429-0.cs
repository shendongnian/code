    IEnumerable<Device> devices = 
      from device in myXML.Descendants("device")
      select new Device(device.Attribute("id").Value, device.Attribute("name").Value)
      {
         Interfaces = (from interface in device.Elements("Interface")
                       select new DeviceInterface(
                            interface.Attribute("id").Value,
                            interface.Attribute("description").Value)
                      ).ToList() //or Array as you prefer
      }
