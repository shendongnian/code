  public static object FindDottedProperty(this object input, string propertyName)
  {
    if (input == null)
      return null;
    if (string.IsNullOrEmpty(propertyName))
      return null;
    Queue<string> props = new Queue<string>(propertyName.Split('.'));
    if (props.Count == 0) return null;
    //start with input object and roll out property stack from there.
    object ret = input;
    while (props.Count > 0)
    {
      var prop = props.Dequeue();
      if (string.IsNullOrEmpty(prop)) return null;
      /*** ADD INDEXER LOGIC HERE ***/
      //get the property's value based on the current named item
      ret = ret.GetType().GetProperty(prop).GetValue(ret, null);
    }
    //return looked up value
    return ret;
  }
