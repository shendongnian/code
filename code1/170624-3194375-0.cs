    FieldInfo[] fields = typeof(MyDictionary).GetFields();
    foreach (FieldInfo info in fields) {
      string[] item = (string[])info.GetValue(null);
      Console.WriteLine("Array contains {0} items:", item.Length);
      foreach (string s in item) {
        Console.WriteLine("  " + s);
      }
    }
