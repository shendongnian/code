    var lines = File.ReadAllLines("employees.txt").Where(s=> !string.IsNullOrEmpty(s));
    var list = new List<Employee>();
    foreach(var line in lines)
    {
        var arr = line.Split(',');
        var name = arr[0].Trim;
        var number = int.Parse(arr[1].Trim);
        var rate = decimal.Parse(arr[2].Trim);
        var hour  = double.Parse(arr[3].Trim);
        var emp = new Employee(name, number,rate,hour);
        list.Add(emp);
    }
