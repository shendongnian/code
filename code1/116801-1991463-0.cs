      using (var helper = new RichTextBox()) {
        helper.LoadFile(@"c:\temp\test.rtf");
        // Copy line #6
        int startRange = helper.GetFirstCharIndexFromLine(5);
        int endRange = helper.GetFirstCharIndexFromLine(6);
        helper.SelectionStart = startRange;
        helper.SelectionLength = endRange - startRange;
        helper.Copy();
      }
      richTextBox1.SelectAll();
      richTextBox1.Paste();
