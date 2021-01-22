public static class Parser{
  public static DateTime GetDateTime(object value){
    return GetDateTime(value, default(DateTime));
  }
  public static DateTime GetDateTime(object value, DateTime defaultValue){
    try{
      return DateTime.Parse(value.ToString());
    }
    catch{
      return defaultValue;
    }
  }
}
