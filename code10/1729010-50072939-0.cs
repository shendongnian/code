    var result = url.Split(new [] { '\r', '\n' }); // converting string to lines
    for (int i=0;i<=result.Length-1;i++) // Finding if EXT text is present and removing them
      {
        if (result[i].Contains("EXT-")
          result.RemoveAt(i);
      }
    string final = string.Join("", result); // converting back to string
