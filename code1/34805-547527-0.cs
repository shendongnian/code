    private void button1_Click(object sender, System.EventArgs e)
    {
        // Use the open file dialog to choose a word document
        if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            // set the file name from the open file dialog
            object fileName = openFileDialog1.FileName;
            object readOnly = false;
            object isVisible = true;
            // Here is the way to handle parameters you don't care about in .NET
            object missing = System.Reflection.Missing.Value;
            // Make word visible, so you can see what's happening
            WordApp.Visible = true;
            // Open the document that was chosen by the dialog
            Word.Document aDoc = WordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible);
            // Activate the document so it shows up in front
            aDoc.Activate();
            // Add the copyright text and a line break
            WordApp.Selection.TypeText("Copyright C# Corner");
            WordApp.Selection.TypeParagraph();
        }
    }
