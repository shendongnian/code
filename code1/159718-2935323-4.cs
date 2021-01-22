      // initialize the SystemInfo instance that you want to pass to the server
      SystemInfo si = new SystemInfo() { SystemName = "My System" };
      // Serialize to a memory stream
      BinaryFormatter bf = new BinaryFormatter();
      MemoryStream ms = new MemoryStream();
      bf.Serialize(ms, si);
      // Call the service, passing the array from the memory stream
      ws.Reports(ms.ToArray());
