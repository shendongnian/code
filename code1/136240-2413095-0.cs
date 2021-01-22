    var args = new object[0];
    foreach(var prop in typeof(User).GetProperties()) {
      if (prop.CanRead) {
        string val = prop.GetGetMethod().Invoke(user, args).ToString();
        sb.Replace("${user." + prop.Name +"}", val);
      }
    }
