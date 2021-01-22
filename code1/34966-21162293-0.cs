    public static string union(this List<string> stringList, String seperator)
    {
       String unionString = "";
       foreach (string stringItem in stringList) {
          unionString += seperator + stringItem; }
       if (unionString != "") { 
          unionString = unionString.Substring(seperator.Length); }
       return unionString;
    }
