    string name = "AL QADEER UR AL REHMAN AL KHALIL UN";
    string systemName = "";
    List<string> list = new List<string> { "AL", "UR", "UN" };
    foreach (var item in name.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries))
        systemName += list.Contains(item) ? "" : item + " ";
