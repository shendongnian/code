    public static List<string> TrimList(this List<string> list)  
        {  
            return list.SkipWhile(l => String.IsNullOrEmpty(l)).Reverse().SkipWhile(l => String.IsNullOrEmpty(l)).Reverse();
        } 
    
