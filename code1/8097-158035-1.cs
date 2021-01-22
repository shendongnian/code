    session.AddStore("C:\\test.pst"); // loads existing or creates a new one, if there is none.
    storage = session.Folders.GetLast(); // grabs root folder of the new fileStorage.
    if (storage.Name != storageName) // if fileStorage is brand new, it has default name.
    {
          storage.Name = "Documents";
          session.RemoveStore(storage); // to apply new fileStorage name, it have to be removed and added again.
          session.AddStore(storagePath);
     }
