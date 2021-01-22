    System.Net.WebClient client = new System.Net.WebClient();
    string definedCodePoints = client.DownloadString(
                             "http://unicode.org/Public/UNIDATA/UnicodeData.txt");
    System.IO.StringReader reader = new System.IO.StringReader(definedCodePoints);
    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
    while(true) {
      string line = reader.ReadLine();
      if(line == null) break;
      int codePoint = Convert.ToInt32(line.Substring(0, line.IndexOf(";")), 16);
      if(codePoint >= 0xD800 && codePoint <= 0xDFFF) {
        //surrogate boundary; not valid codePoint, but listed in the document
      } else {
        string utf16 = char.ConvertFromUtf32(codePoint);
        byte[] utf8 = encoder.GetBytes(utf16);
        //TODO: something with the UTF-8-encoded character
      }
    }
