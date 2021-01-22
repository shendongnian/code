    static int[] ExtractScalars(string s)
    {
      List<int> chars = new List<int>((s.Length * 3) / 2);
      var ee = StringInfo.GetTextElementEnumerator(s);
      while (ee.MoveNext())
      {
        string e = ee.GetTextElement();
        chars.Add(char.ConvertToUtf32(e, 0));
      }
      return chars.ToArray();
    }
