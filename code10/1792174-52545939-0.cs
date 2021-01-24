    //Get the date
    System.DateTime a = System.DateTime.Now;
    //Converts it to string
    string b = a.ToString("yyyy-MM-dd HH:mm:ss");
    System.Console.WriteLine(b);
    //Convert to Byte Array
    byte[] c = System.Text.Encoding.ASCII.GetBytes(b);
    //Convert every byte as hex and join it
    string d = "";
    foreach (byte e in c)
      d += string.Format("{0:x2}", e);
    //Show the result
    System.Console.WriteLine(d);
