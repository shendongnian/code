    string Descript1 = ":1:2:3:4:5";
    Regex pattern = new Regex(":");
    foreach (string sub in pattern.Split(Descript1)) {
      if (sub.Length > 0) {
        Single a = Convert.ToSingle(sub);
      }
    }
