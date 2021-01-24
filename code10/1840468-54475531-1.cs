    public static MyList ToMyCustomType(this YOURWSTYPE input){
    
    return new MyList{
     newTitle = result.Title + " - my custom value",
                          newData = "01/01/2019",
                          newLink = GetCustomLink(result)
    }
    }
    public static List<MyList> ToMyCustomType(this IEnumerable<YOURWSTYPE> input){
     return input.Select(xx=> xx.ToMyCustomType()).ToList();
    }
