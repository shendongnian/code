    var propsNames = new List<string> {"Name", "Description", "HardwareID"};
    var propValues = new List<object> {"USB Input Device", "USB Input Device", new List<object> {"USB\\VID_062A&PID_4102&REV_8113", "USB\\VID_062A&PID_4102" }};
    var propsAndValues = propsNames.Zip(propValues, (name, value) => new {name, value});
    var sb = new StringBuilder();
    foreach (var item in propsAndValues)
    {
        var value = item.value is string 
          ? item.value 
          : string.Join(", ", (IEnumerable<object>)item.value);
        sb.AppendLine(item.name + ": " + value);
    }
