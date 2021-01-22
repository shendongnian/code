    List garbagedObjects = new List();
    garbagedObjects.Add(myComObject1);
    garbagedObjects.Add(myComObject2);
    ...
    foreach(object garbagedObject in garbagedObjects)
    {
      ReleaseObject(garbagedObject);
      garbagedObject = null;
    }
    garbagedObjects = null;
    GC.Collect();
    ...
