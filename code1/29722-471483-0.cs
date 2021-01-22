    [Test]
    public void TestGetLineFromCharIndex_UseAppendText() {
      String[] newlines = new string[] { "<P>one</P>" }; //TextLength == 10
      notepad.txtbox.Lines = newlines;
      notepad.txtbox.AppendText("\n<P>two</P>");
      Expect(notepad.txtbox.GetLineFromCharIndex(15), EqualTo(1));    
    }
    [Test]
    public void TestGetLineFromCharIndex() {
      String[] newlines = new string[] { "<P>one</P>", "<P>two</P>" };
      notepad.txtbox.Lines = newlines;
      Expect(notepad.txtbox.GetLineFromCharIndex(15), EqualTo(1));
    }
