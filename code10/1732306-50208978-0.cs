    string name = "AL QADEER UR AL REHMAN AL KHALIL UN";
    List<string> list = new List<string> { "AL", "UR", "UN" };
    var names = name.Split(' ').ToList();
    names.RemoveAll(x => list.Contains(x));
    name = string.Join(" ", names);
