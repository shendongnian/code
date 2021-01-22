    string result = String.Empty;
    var list = new[]
    { 
        new { Number = 10, Name = "Smith" },
        new { Number = 10, Name = "John" } 
    }.ToList();
    foreach (var item in list)
    {
        result += String.Format("Name={0}, Number={1}\n", item.Name, item.Number);
    }
    MessageBox.Show(result);
