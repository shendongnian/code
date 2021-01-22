    string input = "123xx456yy789";
    string[] delimiters = { "xx", "yy" };
    
    int[] nextPosition = delimiters.Select(d => input.IndexOf(d)).ToArray();
    List<string> result = new List<string>();
    int pos = 0;
    while (true) {
      int firstPos = int.MaxValue;
      string delimiter = null;
      for (int i = 0; i < nextPosition.Length; i++) {
        if (nextPosition[i] != -1 && nextPosition[i] < firstPos) {
          firstPos = nextPosition[i];
          delimiter = delimiters[i];
        }
      }
      if (firstPos != int.MaxValue) {
        result.Add(input.Substring(pos, firstPos - pos));
        result.Add(delimiter);
        pos = firstPos + delimiter.Length;
        for (int i = 0; i < nextPosition.Length; i++) {
          if (nextPosition[i] != -1 && nextPosition[i] < pos) {
            nextPosition[i] = input.IndexOf(delimiters[i], pos);
          }
        }
      } else {
        result.Add(input.Substring(pos));
        break;
      }
    }
