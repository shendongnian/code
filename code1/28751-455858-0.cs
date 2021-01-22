    static void HighlightPhrase(RichTextBox box, string phrase, Color color) {
      int pos = box.SelectionStart;
      string s = box.Text;
      for (int ix = 0; ; ) {
        int jx = s.IndexOf(phrase, ix, StringComparison.CurrentCultureIgnoreCase);
        if (jx < 0) break;
        box.SelectionStart = jx;
        box.SelectionLength = phrase.Length;
        box.SelectionColor = color;
        ix = jx + 1;
      }
      box.SelectionStart = pos;
      box.SelectionLength = 0;
    }
...
    private void button1_Click(object sender, EventArgs e) {
      richTextBox1.Text = "Aardvarks are strange animals";
      HighlightPhrase(richTextBox1, "a", Color.Red);
    }
