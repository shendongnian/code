    private void button2_Click(object sender, EventArgs e)
    {
        // Check that myFile has some text and isn't null.
        if (string.IsNullOrWhitespace(myFile))
            return;
        // Check that the file exists before attempting to move it.
        if (File.Exists(myFile))
            System.IO.File.Move(myFile, @"C:\testing\records\file.pdf");
    }
