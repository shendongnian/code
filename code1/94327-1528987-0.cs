    // list = IList<MyObject>
    
    var strBuilder = new System.Text.StringBuilder();
    
    foreach(var obj in list)
    {
      strBuilder.Append(obj.ToString());
      strBuilder.Append(",");
    }
    
    strBuilder = strBuilder.SubString(0, strBuilder.Length -1);
    return strBuilder.ToString();
