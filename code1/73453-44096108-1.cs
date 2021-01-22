    public string GetBoxedString(string s, Size size, Font font)
    {
      int longestStringLengthInWidth = 0;
      var result = string.Empty;
      if (size.Height < font.Height)
      {
        return string.Empty;
      }
      using (var bmp = new Bitmap(size.Width, size.Height))
      {
        int index = 0;
        var words = this.SplitString(s);
        var measuredSizeBeforeAddingWord = new SizeF(0, 0);
        using (var graphic = Graphics.FromImage(bmp))
        {
          longestStringLengthInWidth = CalculateLongestStringLength(size, font);
          do
          {
            if (words[index].Length > longestStringLengthInWidth)
            {
              //// If a word is longer than the maximum string length for the specified size then break it into characters and add char 0 at the begining of each of those characters
              var brokenCharacters = words[index].Select(c => ((char)0) + c.ToString()).ToList();
              brokenCharacters.Add(" ");
              words.RemoveAt(index);
              words.InsertRange(index, brokenCharacters);
            }
            var measuredSizeAfterAddingWord = graphic.MeasureString(result + (!words[index].EndsWith("\n") ? words[index] + " " : words[index]), font, size);
            if ((words[index].Contains('\n') || measuredSizeAfterAddingWord == measuredSizeBeforeAddingWord) && measuredSizeAfterAddingWord.Height >= size.Height-font.Height)
            {
              return result.TrimEnd();
            }
            measuredSizeBeforeAddingWord = measuredSizeAfterAddingWord;
            if (words[index].Contains((char)0))
            {
              result += words[index].Replace(((char)0).ToString(), string.Empty);
            }
            else
            {
              result += (!words[index].EndsWith("\n") ? words[index] + " " : words[index]);
            }
            index++;
          }
          while (index < words.Count);
        }
      }
      return result.TrimEnd();
    }
    private List<string> SplitString(string s)
    {
      var words = s.Split(' ').ToList();
      var index = 0;
      do
      {
        // If a word contains Enter key(s) then break it into more words and replace them with the original word.
        if (!words[index].Contains("\n"))
        {
          index++;
          continue;
        }
        var enterSplitWords = (words[index] + " ").Split('\n');
        var brokenWords = enterSplitWords.Select(str => (enterSplitWords.LastOrDefault() != str ? str + "\n" : str).Replace(" ", string.Empty)).ToList();
        words.RemoveAt(index);
        words.InsertRange(index, brokenWords);
        index += brokenWords.Count;
      }
      while (index < words.Count);
      return words;
    }
    private static int CalculateLongestStringLength(Size size, Font font)
    {
      var tempString = string.Empty;
      var longestStringLengthInWidth = 0;
      using (var bmp = new Bitmap(size.Width, size.Height))
      {
        using (var graphic = Graphics.FromImage(bmp))
        {
          do
          {
            if (Math.Floor(graphic.MeasureString(tempString, font, size).Height) <= font.Height)
            {
              longestStringLengthInWidth++;
            }
            else
            {
              break;
            }
            tempString += "x";
          } while (true);
        }
      }
      return longestStringLengthInWidth;
    }
  }
