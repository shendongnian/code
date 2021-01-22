    public static object GetObjectMemberValue(object myObject, string memberName)
    {
      PropertyInfo dateProperty = myObject.GetType().GetProperty(memberName);
      return dateProperty.GetValue(myObject, null);
    }
