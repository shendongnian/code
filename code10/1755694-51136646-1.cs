    string jstr = "{\"HardwareInformation\": {\"NumberOfProcessors\": 8,\"PageSize\": 4096,\"ProcessorType\": 586,\"ProcessorTypeText\": \"]\",\"ActiveProcessorMask\": 255},\"SystemInformation\": {\"ComputerName\": \"PD-AT-23006\",\"UserName\": \"230010\",\"SystemDirectory\": \"C:\\\\Windows\\\\system32\",\"WindowsDirectory\": \"C:\\\\Windows\",\"Is64BitWindows\": 1},\"EnvironmentVariables\": {\"OS\": \"Windows_NT\",\"PATH\": \"C:\\\\Program Files (x86)\\\\NVIDIACorporation\\\\PhysX\\\\Common\"}}";
    var info = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(jstr);
    DataTable dt = new DataTable();
    var Maxcolumn = info.Count;
    var maxRows = info.Select(x => x.Value.Count).Max();
    // Add Columns
    foreach (var column in info)
        dt.Columns.Add(new DataColumn(column.Key, typeof(string)));
    // Add Rows
    for (int r = 0; r < maxRows; r++)
    {
        DataRow newrow = dt.NewRow();
        for (int c = 0; c < Maxcolumn; c++)
        {
            var columnDic = info.Values.ElementAt(c);
            var key = r < columnDic.Count ? columnDic.Keys.ElementAt(r) : "";
            var value = r < columnDic.Count ? columnDic.Values.ElementAt(r).ToString() : "";
            newrow[c] = key + ": " + value;
        }
        dt.Rows.Add(newrow);
    }
