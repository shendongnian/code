      public static IList<string> WordWrap(
         string text,
         Font printFont,
         Graphics graphics,
         IList<SizeF> sizeF,
         string tooLongText)
      {
         List<string> list = new List<string>();
         int charsFit;
         int linesFilled;
         foreach (SizeF size in sizeF)
         {
            graphics.MeasureString(
               text,
               printFont,
               size,
               new StringFormat(),
               out charsFit,
               out linesFilled);
            
            char[] whitespace = new[] { ' ', '\t', '\r', '\n' };
            int index = charsFit;
            if (text.Length > charsFit)
               index = text.LastIndexOfAny(whitespace, charsFit);
            if (index < 0) index = charsFit;
            string rv = text.Substring(0, index).Trim();
            text = text.Substring(index).Trim();
            list.Add(rv);
         }
         if (!string.IsNullOrEmpty(text))
         {
            string lastText = list[list.Count - 1];
            SizeF size = sizeF[sizeF.Count - 1];
            charsFit = 0;
            string newLastText = lastText + Environment.NewLine + tooLongText;
            while (charsFit < newLastText.Length)
            {
               graphics.MeasureString(
                  newLastText,
                  printFont,
                  size,
                  new StringFormat(),
                  out charsFit,
                  out linesFilled);
               lastText = lastText.Substring(0, lastText.Length - 1);
               newLastText = lastText + Environment.NewLine + tooLongText;
            }
            list.RemoveAt(list.Count - 1);
            list.Add(newLastText);
         }
         return list;
      }
