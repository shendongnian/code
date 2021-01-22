    [TestMethod]
    public void TestDeleteLine_SingleLine() {
       var rtb = new RichTextBox();
       rtb.Text = "This is line1.\n";
       rtb.DeleteLine(0);
       var expected = "";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_BlankLastLine() {
       var rtb = new RichTextBox();
       rtb.Text = "\n";
       rtb.DeleteLine(1);
       var expected = "\n";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_SingleLineNoEOL() {
       var rtb = new RichTextBox();
       rtb.Text = "This is line1.";
       rtb.DeleteLine(0);
       var expected = "";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_FirstLine() {
       var rtb = new RichTextBox();
       rtb.Text = "This is line1.\nThis is line2.\nThis is line3.";
       rtb.DeleteLine(0);
       var expected = "This is line2.\nThis is line3.";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_MiddleLine() {
       var rtb = new RichTextBox();
       rtb.Text = "This is line1.\nThis is line2.\nThis is line3.";
       rtb.DeleteLine(1);
       var expected = "This is line1.\nThis is line3.";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_LastLine() {
       var rtb = new RichTextBox();
       rtb.Text = "This is line1.\nThis is line2.\nThis is line3.";
       rtb.DeleteLine(2);
       var expected = "This is line1.\nThis is line2.\n";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_OneBlankLine() {
       var rtb = new RichTextBox();
       rtb.Text = "\n";
       rtb.DeleteLine(0);
       var expected = "";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod]
    public void TestDeleteLine_BlankLines() {
       var rtb = new RichTextBox();
       rtb.Text = "\n\n\n\n\n";
       rtb.DeleteLine(2);
       var expected = "\n\n\n\n";
       Assert.AreEqual(expected, rtb.Text);
    }
    [TestMethod, ExpectedException(typeof(InvalidOperationException))]
    public void TestDeleteLine_Exception_BeforeFront() {
       var rtb = new RichTextBox();
       rtb.Text = "\n\n\n\n\n";
       rtb.DeleteLine(-1);
    }
    [TestMethod, ExpectedException(typeof(InvalidOperationException))]
    public void TestDeleteLine_Exception_AfterEnd() {
       var rtb = new RichTextBox();
       rtb.Text = "\n\n";
       rtb.DeleteLine(3);
    }
