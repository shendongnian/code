    List<string> strings = new List<string>() {"2016/7/3","2025/12/01" };
    //List of DateTime objects
    List<string> strings2 = new List<string>() { "25", "21.12" };
    //List of Double objects
    List<string> strings3 = new List<string>() { "true", "false" };
    //List of bool objects
    List<string> strings4 = new List<string>() { "12", "0" };
    //List of int objects
    List<string> strings5 = new List<string>() { (new TimeSpan(2,3,3)).ToString(), "0" };
    //List of TimeSpan objects
    List<string> strings6 = new List<string>() { "2016/7/3" , "3"};
    //string
    var result = GetMostLikelyType(strings);
    var result2 = GetMostLikelyType(strings2);
    var result3 = GetMostLikelyType(strings3);
    var result4 = GetMostLikelyType(strings4);
    var result5 = GetMostLikelyType(strings5);
    var result6 = GetMostLikelyType(strings6);
 
