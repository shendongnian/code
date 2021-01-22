    List<string> lines = new List<string>();
    while (message.Length > 60) {
      int idx = message.LastIndexOf(' ', 60);
      lines.Add(message.Substring(0, idx));
      message = message.Substring(idx + 1, message.Length - (idx + 1));
    }
    lines.Add(message);
