    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
        FileObject fileObject = (FileObject)listBox1.SelectedItem;
        // Populate the RichTextBox here - I output to the Console as a demo
        Console.WriteLine(fileObject.FileContent);
    }
