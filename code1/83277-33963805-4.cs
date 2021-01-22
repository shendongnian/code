    public static void DeleteLine([NotNull] this RichTextBox pRichTextBox, int pLineIndex) {
       if (pLineIndex < 0 || pLineIndex >= pRichTextBox.Lines.Length)
          throw new InvalidOperationException("There is no such line.");
       var start = pRichTextBox.GetFirstCharIndexFromLine(pLineIndex);
       var isLastLine = pLineIndex == pRichTextBox.Lines.Length - 1;
       var nextLineIndex = pLineIndex + 1;
         
       var end = isLastLine
          ? pRichTextBox.Text.Length - 1
          : pRichTextBox.GetFirstCharIndexFromLine(nextLineIndex) - 1;
       var length = end - start + 1;
       pRichTextBox.Text = pRichTextBox.Text.Remove(start, length);
    }
