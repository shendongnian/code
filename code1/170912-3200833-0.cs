    var _newNameObjectList = new List<NameObject>();
    
    foreach(var nameObject in NameObjecs)
    {
       if(_newNameObjectList.Select(x => x.Name == nameObject.Name).ToList().Count > 0)
       {
          _newNameObjectList.RemoveAll(x => x.Name == nameObject.Name);
          continue;
       }
       else
       {
          _newNameObjectList.Add(nameObject); 
       }
    }
