    using Newtonsoft.Json.Linq;
    string result = Convert.ToString(jsExecutor.ExecuteScript(func1));
    Console.Write("result = " + result);
    List<Timing> list = JToken.Parse(result).ToObject<List<Timing>>();
    Console.Write("result = " + JToken.FromObject(list));
    // or access using dynamic
    dynamic dynamicList = JToken.Parse(jsExecutor.ExecuteScript(func1)); 
    for (var i = 0; i < dynamicList.Count; i++) {
       Console.Write(dynamicList[i]);
    }
