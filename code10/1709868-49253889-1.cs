      String source = "0000095700012A27";
      String txtbox_input = "-2,4,-4,4,2";
      String pattern = ",";
      var data = txtbox_input
        .Split(new string[] { pattern }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => Math.Abs(int.Parse(item))) // Math.Abs - ignoring minus
        .Select(length => {
          string item = source.Substring(0, length);
          source = source.Substring(length);
          return item;
        })
     // .Select(item => Convert.ToUInt16(item, 16)) // if you want UInt16 items
        .ToArray(); // Let's have an array of chunks
      Console.Write(string.Join(",", data));
