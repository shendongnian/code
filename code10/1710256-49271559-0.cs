    string jsonString = YourGetJsonStringMethod();
    List<Employee> employees = new List<Employee>();
    dynamic data = System.Web.Helpers.Json.Decode(jsonString);
    dynamic results = data["result"]["execution-results"]["results"];
    if (results.Length > 1)
    {
        for (var i = 1; i < results.Length; i++)
        {
            var dynamicEmployee = results[i]["value"]["com.myteam.rbffiyatlama2.Employee"];
            dynamicEmployee["salary"] = (int) dynamicEmployee["salary"];
            var encoded = System.Web.Helpers.Json.Encode(dynamicEmployee);
            employees.Add(System.Web.Helpers.Json.Decode<Employee>(encoded));
        }
    }
